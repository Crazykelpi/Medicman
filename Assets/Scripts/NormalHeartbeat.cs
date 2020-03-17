using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Hier berekenen we de gemiddelde hartslag van de speler, om te bepalen wanneer we de hartslagtekst in het rood laten gaan en of je naar
 * het volgende level mag gaan.
 * Pas hier niets aan.
 */

public class NormalHeartbeat : MonoBehaviour
{
    public SerialPort serial = new SerialPort("COM5", 115200);
    public Text instructiontext;
    public List<int> averagebeatlist;
    public static int averagebeat;
    public event SerialDataReceivedEventHandler DataReceived;
    public SerialDataReceivedEventArgs e;
    public static bool UI=false;
    private void Start()
    {
        OpenConnection();
        instructiontext.text = "Put the sensor on your finger and wait until we calculated your average b/m.";
        UI = false;
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
    private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        Debug.Log("raw: " + indata);
        string output = AnalyseBeats(indata);

        string[] splitoutput = output.Split(',');
        if (splitoutput[0] != string.Empty)
        {
            if(int.TryParse(splitoutput[0], out int result))
            {
                averagebeatlist.Add(result);
                Debug.Log(result);
                if (averagebeatlist.Count >= 10)
                {
                    int sum = 0;
                    foreach (int element in averagebeatlist)
                    {
                        sum += element;
                    }
                    averagebeat = sum / averagebeatlist.Count;
                    instructiontext.text = "Average b/m calculated.";
                    UI = true;
                }
            }
            


        }
        

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

            if (int.TryParse(heartratenumber, out int result))
            {
                if (result == 0)
                {
                    return string.Empty;
                }
                

            }
            
            
            return heartratenumber + "," + statusnumber;





        }
        catch (IndexOutOfRangeException)
        {
            return string.Empty;
        }


       


    }
    void Update()
    {
        if(UI==false)
        {
            DataReceivedHandler(serial, e);
        }
        else
        {
            serial.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
            serial.Close();
        }
       
    }
    void OnApplicationQuit()
    {
        serial.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
        serial.Close();
    }
}
