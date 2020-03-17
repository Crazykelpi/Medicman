using UnityEngine;
using System.Collections;
/*
 * Dit script zorgt ervoor dat je zakklamp schijnt. In normale omstandigheden zal hij 99% van de tijd licht geven en 1% niet, om het effect te
 * creëren dat de zaklamp flikkert.
 * Wanneer slenderman dichterbij is, zal de zaklamp feller flikkeren (50% van de tijd is het licht uit)
 */
public class LightToggle : MonoBehaviour {

	private Light flashlight;
	private float random;
	public static float distance;
	public GameObject player;
	public Renderer slender;

	void Start(){
		flashlight = gameObject.GetComponent<Light>();
	}

	void LateUpdate(){
		distance = Vector3.Distance(slender.transform.position, player.transform.position);
		random = Random.Range (0f, 100f);// maak 100f groter om meer kans te hebben op flikkeren. Moet groter zijn dan "99". Zie volgend
										//commentaar.
		if(Stresslevel.stresslevel1done)
		{
			
			if (random >= 99) //als "random" groter of gelijk is dan 99, dan zal de zaklamp uitgaan. Verlaag dit getal als je de zaklamp meer
							  //wilt laten flikkeren. 
								/*
								 * Random.Range(0f,100f)
								 *				    ^
								 *				    |
								 *				    |
								 * Zorg ervoor dat het getal dat je kiest kleiner is dan het getal met de pijl. In dit geval 100f
								 */
			 
			{
				flashlight.enabled = false;
			}
			else 
			{
				flashlight.enabled = true;
			}
			if (distance <= 30f && Pausemenu.pausemenu == false)//verander de afstand (30f tussen speler en slender) waarop de zaklamp heel fel 
																//begint te flikkeren.
			{
				FlashLightFlickering();
			}
		}
		else
		{
			flashlight.enabled = false;
		}

		
	}
	public void FlashLightFlickering()
	{
		random = Random.Range(0, 2); //Als slender dichtbij komt (30f), zal de zaklamp heel fel beginnen flikkeren. Verander de "2" in een groter
									 //getal als je minder flikkering wilt. Zorg dat dit getal groter is dan de "1" hieronder.
		if(random>=1)
		{
			flashlight.enabled = false;
		}
		else
		{
			flashlight.enabled = true;
		}
	}
}
