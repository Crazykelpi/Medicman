using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Dit script zorgt vooral voor de geluiden: de voetstappen, maar ook het geluid dat je hoort wanneer je een papier neemt, de klokgeluiden etc.
 * Ook worden hier bijgehouden hoeveel papiertjes je hebt verzamelt.
 * 
 * Je kan de geluiden aanpassen door in unity op 'scene1' te klikken en dan op 'Player'. Scroll daar naar beneden tot je 'footsteps (Script)' ziet.
 * Hier mag je het geluid 'heartbeat', 'scream' en 'heavybreathing' vervangen door een geluid naar keuze.
 * Je kan een geluid in unity slepen door het geluid naar keuze vanop je computer naar de unity files te slepen en in 'assets' te stoppen. 
 * (zorg dat je weet waar je het geluid steekt zodat je het in unity terugvindt. Als je het geluid in assets hebt gestoken kan je onder project 
 *  zoeken naar de naam van het bestand. Sleep je bestand naar het script en laat het los op het geluid dat je wilt veranderen.
 * 
 * !!!!VERANDER 'sound', 'siren' en countText NIET!!!!!
 * 'scream' wordt afgespeeld wanneer je de eerste of tweede papiertje vindt en als je in level 2 of hoger zit.
 * 'heartbeat' wordt afgespeeld wanneer je het derde of 4de papiertje vindt en als je in level 3 of hoger zit.
 * 'heavybreathing' wordt afgespeeld wanneer je het vijfde papiertje vindt en als je in level 4 of hoger zit.
 * 
 * Pas hier in het script zelf niets aan.
 */

public class Footsteps : MonoBehaviour {

	public AudioSource sound;
	public AudioSource siren;
	public AudioClip hearthbeat;
	public AudioClip scream;
	public AudioClip heavybreathing;
	public GUIText countText;
	public static int count;
	private float timer = 3f;
	private bool played = false;


	void Start()
	{
		count = 0;
		played = false;
		setCountText();
	}

	void Update()
	{
		if (played)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f && Pausemenu.pausemenu==false)
			{
				played = false;
				if(count<=2 && Stresslevel.stresslevel1done)
				{
					siren.PlayOneShot(scream);
				}
				else if(count<=4 && Stresslevel.stresslevel2done)
				{
					siren.PlayOneShot(hearthbeat);
				}
				else if(Stresslevel.stresslevel3done)
				{
					siren.PlayOneShot(heavybreathing);
				}
				
				
			}

		}
		else if (timer <= 0f && !siren.isPlaying && Pausemenu.pausemenu==false && Stresslevel.stresslevel1done)
		{
			siren.Play();
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
		{
			if(Pausemenu.pausemenu==false)
			{
				sound.Play();

			}

		}
		if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
		{
			sound.Pause();

		}
		if(Pausemenu.pausemenu==true)
		{
			sound.Pause();
			siren.Pause();
		}
	}

	void setCountText()
	{
		countText.text = "Notes: " + count.ToString();
		if (count >= 1 && !played)
		{
			played = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Note")
		{
			other.gameObject.SetActive(false);
			count++;
			if(count>=6)
			{
				SceneManager.LoadScene("won");
			}
			MoveSlender.start = true;
			setCountText();
		}
	}




}
