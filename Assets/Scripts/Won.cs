using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Dit script zorgt ervoor dat er knoppen komen die je de mogelijkheid geven om opnieuw te spelen of het spel af te sluiten.
 * Je mag hier aanpassing doen bij de '//'.
 */
public class Won : MonoBehaviour
{
	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 40), "Play again"))//verander 'play again' in een tekstje die je
																										//graag op die knop hebt staan.
		{
			SceneManager.LoadScene("TitleScreen");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 40), "Quit game"))//verander 'quit game' in een tekstje die je
																									   //graag op die knop hebt staan.
		{
			Application.Quit();
		}
	}
}
