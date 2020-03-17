using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Dit script zorgt ervoor dat slender beweegt vanaf het moment dat je je eerste papiertje vindt. Hier wordt vooral de snelheid van slender
 * aangepast. Dit is afhankelijk van hoe van slender is (hoe verder weg hoe sneller), maar ook in welk level je bevindt (hoe hoger het level hoe
 * sneller).
 * Scroll naar beneden om te kijken waar je aanpassing kan doen.
 */
public class MoveSlender : MonoBehaviour {
	
	public GameObject player;
	public Renderer slender;
	public static float speed;
	public Transform myTransform;
	private float timer = 5.0f;
	public static bool start = false;
	public static float distance;
	private Vector3 yAxis;
	public static int extraspeed = 0;

	void Start()
	{
		start = false;
		myTransform.position = new Vector3(1866, 1.7f, 9); //startpostitie slender, verander dit  naar een dichter locatie om sneller gepakt te 
														   //worden.
	}
	void Update()
	{
		

		distance = Vector3.Distance(myTransform.position, player.transform.position);
		timer -= Time.deltaTime;
		if(start)
		{
			if (distance < 3f) //als slender binnen een afstand van 3 is, is het spel gedaan. Hoe hoger dit is hoe sneller het spel gedaan is.
							   //Verhoog dit niet te veel want anders zal het spel al gedaan zijn voor je slender hebt gezien.
			{
				SceneManager.LoadScene("GameOver"); 
			}

			if (Stresslevel.stresslevel5done)
			{
				if (DataHandler.currentbeat > NormalHeartbeat.averagebeat)
				{
					speed = 8; //snelheid van slender na level 5
					if (distance > 100f)
					{
						speed *= 2; // als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
					extraspeed = 5;
					float restspeed = speed - extraspeed;
					if (speed <= restspeed + 5)
					{
						speed += extraspeed;
					}



				}
				else if (DataHandler.currentbeat <= NormalHeartbeat.averagebeat)
				{

					speed = 8; //snelheid van slender als level 5 gedaan is.
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}

				}
			}
			else if (Stresslevel.stresslevel4done)
			{

				if (DataHandler.currentbeat > NormalHeartbeat.averagebeat)
				{
					speed = 7;//snelheid van slender in level 5
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
					extraspeed = 5;
					float restspeed = speed - extraspeed;
					if (speed <= restspeed + 5)
					{
						speed += extraspeed;
					}



				}
				else if (DataHandler.currentbeat <= NormalHeartbeat.averagebeat)
				{

					speed = 7;//snelheid van slender in level 5
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
				}
			}
			else if (Stresslevel.stresslevel3done)
			{
				if (DataHandler.currentbeat > NormalHeartbeat.averagebeat)
				{
					speed = 6;//snelheid van slender in level 4
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
					extraspeed = 5;
					float restspeed = speed - extraspeed;
					if (speed <= restspeed + 5)
					{
						speed += extraspeed;
					}



				}
				else if (DataHandler.currentbeat <= NormalHeartbeat.averagebeat)
				{

					speed = 6;//snelheid van slender in level 4
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
				}
			}
			else if (Stresslevel.stresslevel2done)
			{
				if (DataHandler.currentbeat > NormalHeartbeat.averagebeat)
				{
					speed = 5;//snelheid van slender in level 3
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
					extraspeed = 5;
					float restspeed = speed - extraspeed;
					if (speed <= restspeed + 5)
					{
						speed += extraspeed;
					}



				}
			}
			else if (DataHandler.currentbeat <= NormalHeartbeat.averagebeat)
			{

				speed = 5;//snelheid van slender in level 3
				if (distance > 100f)
				{
					speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
				}
			}
			else if (Stresslevel.stresslevel1done)
			{
				if (DataHandler.currentbeat > NormalHeartbeat.averagebeat)
				{
					speed = 4;//snelheid van slender in level 2
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
					extraspeed = 5;
					float restspeed = speed - extraspeed;
					if (speed <= restspeed + 5)
					{
						speed += extraspeed;
					}



				}
				else if (DataHandler.currentbeat <= NormalHeartbeat.averagebeat)
				{

					speed = 4;//snelheid van slender in level 2
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
				}

			}
			else
			{


				if (DataHandler.currentbeat > NormalHeartbeat.averagebeat)
				{
					speed = 3;//snelheid van slender in level 1
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}
					extraspeed = 5;
					float restspeed = speed - extraspeed;
					if (speed <= restspeed + 5)
					{
						speed += extraspeed;
					}



				}
				else if (DataHandler.currentbeat <= NormalHeartbeat.averagebeat)
				{

					speed = 3;//snelheid van slender in level 1
					if (distance > 100f)
					{
						speed *= 2;// als slender op meer dan 100 afstand is, zal de snelheid verdubbelt worden.
					}




				}
				Vector3 yAxis = myTransform.position;
				yAxis.y = 1.7f;
				myTransform.position = yAxis;
				myTransform.position += myTransform.forward * speed * Time.deltaTime;
			}
				
		}			



					
		
		
		
	}
	
}
