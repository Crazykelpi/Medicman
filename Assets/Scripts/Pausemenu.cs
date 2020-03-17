using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/*
 * Dit is het pausemenu, hier wordt er voor gezorgd dat je niet meer kan rondkijken en dat er een pausemenu verschijnt. Ook wordt de tijd stilgezet
 * om te vermijden dat jij en slender kunnen bewegen.
 * Hier pas je best ook niets aan.
 */
public class Pausemenu : MonoBehaviour
{
    public static bool pausemenu = false;
    public GameObject PausemenuUI;
    private void Start()
    {
        Time.timeScale = 1f;
        pausemenu = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
          

            
            if (pausemenu)
            {
                Resume();
            }
            else
            {
                
                Pause();
                
            }
            

        }
    }
    public void Resume()
    {
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausemenu = false;
       
    }
    void Pause()
    {
        PausemenuUI.SetActive(true);
        pausemenu = true;
        Time.timeScale = 0f;
        
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
}
