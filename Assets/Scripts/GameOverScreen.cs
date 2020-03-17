using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Als slenderman je te pakken heeft, zal je het gameoverscherm zien. Dit script zorgt er voor dat de knoppen 'try again' je terug naar het
 * startscherm brengen en de 'quit' button zorgt ervoor dat je stopt met spelen.
 * Scroll naar beneden om iets aan te passen bij de "//"
 */

public class GameOverScreen : MonoBehaviour {

	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 40), "Try again")) //verander hier de tekst "Try again"
																									//om een andere tekst op de knop te krijgen
		{
			SceneManager.LoadScene("Titlescreen");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 +50, 200, 40), "Quit game"))//verander hier de tekst "Quit game"
																									  //om een andere tekst op de knop te krijgen
		{
			Application.Quit();
		}
	}







}
