using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Dit script zorgt voor alles dat met de (stress)levels te maken heeft. Het laten zien van de tijd tussen de levels tot de verschillende effecten.
 * Scroll naar beneden om te kijken wat je kan aanpassen bij de "//".
 */
public class Stresslevel : MonoBehaviour
{
    public Material littleskyboxdark;
    public Material skyboxlight;
    public Material darkskybox;
    private float time = 120f;
    private float texttime = 3f;
    public Text timertext;
    public Text Leveltext;
    public static bool stresslevel1done=false;
    public static bool stresslevel2done = false;
    public static bool stresslevel3done = false;
    public static bool stresslevel4done = false;
    public static bool stresslevel5done = false;
    public List<int> beatperlevel;
    void Start()
    {
        stresslevel1done = false;
        stresslevel2done = false;
        stresslevel3done = false;
        stresslevel4done = false;
        stresslevel5done = false;
        time = 120f; // 120 = 2 minuten, verander als je level 1 sneller wilt laten gaan. Bv. 80f wordt 1 minuut en 20 seconden.
        texttime = 3f; // dit is hoe lang de tekst 'level 1' verschijnt. Dit zijn 3 seconden.
        TimerText();       
    }
   
    private void Update()
    {
        
        if (stresslevel1done==false)
        {
          
            

            
            Stresslevel1();
            
            
        }
        else if(stresslevel2done==false)
        {
            
            Stresslevel2();
            
        }
        else if(stresslevel3done == false)
        {
            Stresslevel3();

        }
        else if (stresslevel4done == false)
        {
            
            Stresslevel4();
            
        }
        else if(stresslevel5done == false)
        {
            
            Stresslevel5();
            
        }
        
        


    }
    void Stresslevel1()
    {
        Leveltext.text = "Level 1"; //Pas dit aan als je een andere tekst wil zien om aan te kondigen dat je naar een ander level gaat.

        if (texttime > 0)
        {
            texttime -= Time.deltaTime;
            if (Pausemenu.pausemenu)
            {
                Leveltext.text = "";
            }
        }
        else
        {
            Leveltext.text = "";
        }
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText();
            if(DataHandler.currentbeat!=0)
            {
                beatperlevel.Add(DataHandler.currentbeat);
            }
            
            
            
            
        }
        else
        {
            time = 120f;// 120 = 2 minuten, verander als je level 2 sneller wilt laten gaan. Bv. 80f wordt 1 minuut en 20 seconden.
            texttime = 3f;// dit is hoe lang de tekst 'level 2' verschijnt. Dit zijn 3 seconden.

            if (beatperlevel.Count>0)
            {
                int sum = 0;
                foreach (int element in beatperlevel)
                {
                    sum += element;
                }
                int average = sum / beatperlevel.Count;
                beatperlevel.Clear();
                if (average > NormalHeartbeat.averagebeat)
                {

                    Stresslevel1();
                }
                else
                {
                    RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f, 0); //hoe lager de cijfers, hoe donkerder.
                    stresslevel1done = true;
                }
            }
            else
            {
               
                Stresslevel1();
                
            }
            
            
            
        }
    }
    void Stresslevel2()
    {
        Leveltext.text = "Level 2";//Pas dit aan als je een andere tekst wil zien om aan te kondigen dat je naar een ander level gaat.
        if (texttime > 0)
        {
            texttime -= Time.deltaTime;
            if (Pausemenu.pausemenu)
            {
                Leveltext.text = "";
            }
        }
        else
        {
            Leveltext.text = "";
        }
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText();
            if (DataHandler.currentbeat != 0)
            {
                beatperlevel.Add(DataHandler.currentbeat);
            }




        }
        else
        {
            time = 120f;// 120 = 2 minuten, verander als je level 3 sneller wilt laten gaan. Bv. 80f wordt 1 minuut en 20 seconden.
            texttime = 3f;// dit is hoe lang de tekst 'level 3' verschijnt. Dit zijn 3 seconden.

            if (beatperlevel.Count > 0)
            {
                int sum = 0;
                foreach (int element in beatperlevel)
                {
                    sum += element;
                }
                int average = sum / beatperlevel.Count;
                beatperlevel.Clear();
                if (average > NormalHeartbeat.averagebeat)
                {

                    Stresslevel2();
                }
                else
                {
                    RenderSettings.skybox = littleskyboxdark;
                    RenderSettings.ambientLight = new Color(0.4f, 0.4f, 0.4f, 0);//hoe lager de cijfers, hoe donkerder.
                    stresslevel2done = true;
                }
            }
            else
            {
                
                Stresslevel2();
                
            }
           
           
        }
    }
    void Stresslevel3()
    {
        Leveltext.text = "Level 3";//Pas dit aan als je een andere tekst wil zien om aan te kondigen dat je naar een ander level gaat.
        if (texttime > 0)
        {
            texttime -= Time.deltaTime;
            if (Pausemenu.pausemenu)
            {
                Leveltext.text = "";
            }
        }
        else
        {
            Leveltext.text = "";
        }
        
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText();
            if (DataHandler.currentbeat != 0)
            {
                beatperlevel.Add(DataHandler.currentbeat);
            }


        }
        else
        {
            time = 120f;// 120 = 2 minuten, verander als je level 3 sneller wilt laten gaan. Bv. 80f wordt 1 minuut en 20 seconden.
            texttime = 3f;// dit is hoe lang de tekst 'level 3' verschijnt. Dit zijn 3 seconden.

            if (beatperlevel.Count > 0)
            {
                int sum = 0;
                foreach (int element in beatperlevel)
                {
                    sum += element;
                }
                int average = sum / beatperlevel.Count;
                beatperlevel.Clear();
                if (average > NormalHeartbeat.averagebeat)
                {

                    Stresslevel3();
                }
                else
                {
                    RenderSettings.skybox = darkskybox;
                    RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f, 0);//hoe lager de cijfers, hoe donkerder.
                    stresslevel3done = true;
                }
            }
            else
            {
                
                Stresslevel3();
               
            }
           
            
        }
    }
    void Stresslevel4()
    {
        Leveltext.text = "Level 4";//Pas dit aan als je een andere tekst wil zien om aan te kondigen dat je naar een ander level gaat.
        if (texttime > 0)
        {
            texttime -= Time.deltaTime;
            if (Pausemenu.pausemenu)
            {
                Leveltext.text = "";
            }
        }
        else
        {
            Leveltext.text = "";
        }
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText();
            if (DataHandler.currentbeat != 0)
            {
                beatperlevel.Add(DataHandler.currentbeat);
            }




        }
        else
        {
            time = 120f;// 120 = 2 minuten, verander als je level 4 sneller wilt laten gaan. Bv. 80f wordt 1 minuut en 20 seconden.
            texttime = 3f;// dit is hoe lang de tekst 'level 4' verschijnt. Dit zijn 3 seconden.

            if (beatperlevel.Count > 0)
            {
                int sum = 0;
                foreach (int element in beatperlevel)
                {
                    sum += element;
                }
                int average = sum / beatperlevel.Count;
                beatperlevel.Clear();
                if (average > NormalHeartbeat.averagebeat)
                {

                    Stresslevel4();
                }
                else
                {
                    RenderSettings.ambientLight = new Color(0, 0, 0, 0);
                    stresslevel4done = true;
                }
            }
            else
            {
                
                Stresslevel4();
                
            }
           
            
        }
    }
    void Stresslevel5()
    {
        Leveltext.text = "Level 5";//Pas dit aan als je een andere tekst wil zien om aan te kondigen dat je naar een ander level gaat.
        if (texttime > 0)
        {
            texttime -= Time.deltaTime;
            if (Pausemenu.pausemenu)
            {
                Leveltext.text = "";
            }
        }
        else
        {
            Leveltext.text = "";
        }
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText();
            if (DataHandler.currentbeat != 0)
            {
                beatperlevel.Add(DataHandler.currentbeat);
            }




        }
        else
        {
            time = 120f;// 120 = 2 minuten, verander als je level 5 sneller wilt laten gaan. Bv. 80f wordt 1 minuut en 20 seconden.
            texttime = 3f;// dit is hoe lang de tekst 'level 5' verschijnt. Dit zijn 3 seconden.

            if (beatperlevel.Count > 0)
            {
                int sum = 0;
                foreach (int element in beatperlevel)
                {
                    sum += element;
                }
                int average = sum / beatperlevel.Count;
                beatperlevel.Clear();
                if (average > NormalHeartbeat.averagebeat)
                {

                    Stresslevel5();
                }
                else
                {
                    RenderSettings.fogDensity = 0.1f;//hoe hoger het cijfer, hoe donkerder.
                    stresslevel5done = true;
                }
            }
            else
            {
                
                Stresslevel5();
               
            }
           
            
        }
    }
    void TimerText()
    {
        
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        if(seconds<10)
        {
            
            timertext.text = "Time till next level: " + minutes + ":0" + seconds; // pas hier de tekst aan om duidelijk te
        }                                                                         // maken hoeveel tijd er nog is voor je naar een 
                                                                                  //ander level gaat.
        else
        {
            timertext.text = "Time till next level: " + minutes + ":" + seconds;// pas hier de tekst aan om duidelijk te
        }                                                                         // maken hoeveel tijd er nog is voor je naar een 
                                                                                  //ander level gaat.
    

}
    

}
