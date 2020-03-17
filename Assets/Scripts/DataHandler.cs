using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System;
using UnityEngine.UI;
using System.ComponentModel;
/*
Dit is het script dat de data van de arduino zal inlezen en formateren om te displayen in het spel en te gebruiken in algoritmes. 
We raden aan om hier niets aan te passen, omdat je hier veel verkeerd kunt doen en dan krijg je geen hartslag meer in het spel.
*/
public class DataHandler : MonoBehaviour
{
    public SerialPort serial = new SerialPort("COM5", 115200);
    public Text heartbeattext;
    public event SerialDataReceivedEventHandler DataReceived;
    public SerialDataReceivedEventArgs e;
    public static bool overaverage = true;
    public static int currentbeat=0;
    
    private void Start()
    {
        OpenConnection();
        overaverage = true;
    }
    public void OpenConnection()
    {

        if (serial != null)
        {
            if (serial.IsOpen)
            {
                serial.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                serial.Open();  
                serial.ReadTimeout = 1000;  
                Debug.Log("Port Opened!");
               
            }
        }
        else
        {
            if (serial.IsOpen)
            {
                Debug.Log("Port is already open");

            }
            else
            {
                Debug.Log("Port == null");
            }
        }
        serial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        

    }
    private void Update()
    {
              
        DataReceivedHandler(serial, e);
    }
    string AnalyseBeats(string str)
    {

        try
        {
            string[] split = str.Split('\n');
            string status = split[0];
            string heartrate = split[1];
            string[] statussplit = status.Split(':');
            string[] heartratesplit = heartrate.Split(':');
            string statusnumber = statussplit[1];
            string heartratenumber = heartratesplit[1];
            heartratenumber =heartratenumber.Trim();
            if (int.TryParse(heartratenumber, out int result))
            {
                if(result<=10)
                {
                    return string.Empty;
                }
                
            }
            
            return heartratenumber + "," + statusnumber;





        }
        catch(IndexOutOfRangeException)
        {
            return string.Empty;
        }
       

     

        
        

    }
    void OnApplicationQuit()
    {
        serial.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
        serial.Close();
    }
    private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        
        string output = AnalyseBeats(indata);
        string[] splitoutput = output.Split(',');
        if (splitoutput[0]!=string.Empty)
        {
            if (int.TryParse(splitoutput[1], out int result))
            {
                if (result == 3)
                {
                    if (int.TryParse(splitoutput[0], out int currentheartrate))
                    {
                        currentbeat = currentheartrate;
                        
                        
                        if (currentheartrate > NormalHeartbeat.averagebeat)
                        {
                            heartbeattext.color = Color.red;
                            
                            


                        }
                        else
                        {
                            heartbeattext.color = Color.white;
                           
                            

                        }
                        heartbeattext.text = Convert.ToString(currentheartrate);

                    }
                }
                



            }
            
        }
        




















    }
}
    
