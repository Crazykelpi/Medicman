using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Dit script zorgt voor dat als de gemiddelde hartslag gemeten is het de knoppen 'start game' en 'quit game' laten zien.
 * Scroll naar beneden om iets aan te passen bij de "//"
 */
public class TitleScreen : MonoBehaviour {
	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	void OnGUI()
	{
		if(NormalHeartbeat.UI)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 40), "Start Game")) //verander "Start Game" door een
																											 //andere tekst die je op de knop 
																											// wilt laten zien.
			{
				SceneManager.LoadScene("Scene1");
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 40), "Quit game"))// verander "Quit Game" door een
																											 //andere tekst die je op de knop 
																											 // wilt laten zien.
			{
				Application.Quit();
			}
		}
		
	}
	
}
