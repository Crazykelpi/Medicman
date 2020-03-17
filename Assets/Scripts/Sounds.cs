using UnityEngine;
using System.Collections;
/*
 * Hier wordt ervoor gezorgdt dat als de speler te dicht bij slenderman komt, er een geluid (seenSound) wordt afgespeeld.
 * Je kan hier het 'seenSound' aanpassen. Zie het script 'Footsteps' voor meer informatie.
 * 'seenSound' wordt afgespeeld als je binnen 30 afstand van slender bent.
 * Scroll naar beneden om iets aan te passen bij de "//".
 */
public class Sounds : MonoBehaviour {

	public Transform myTransform;
	public GameObject player;
	public AudioSource siren;
	public Renderer slender;
	public AudioClip seenSound;
	private float distance;
	
	
	void Update()
	{
		if(Pausemenu.pausemenu==false)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			siren.Pause();
			
		}
		distance = Vector3.Distance(myTransform.position, player.transform.position);
		if (distance <= 30f && Pausemenu.pausemenu == false) // pas hier de distance aan bv. '<= 50f' zal er voor zorgen dat slender veel sneller
															 // geluid zal maken. Dit wel alleen maar als je minstens in level 3 zit.
		{
			if(Stresslevel.stresslevel2done)
			{
				siren.PlayOneShot(seenSound);
			}
			
			
			
		}
	
	}
}
