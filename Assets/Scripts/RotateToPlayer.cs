using UnityEngine;
using System.Collections;
/*
 * Dit script zorgt ervoor dat slender altijd naar de speler kijkt.
 * We raden aan om hier niets aan te passen.
 */
public class RotateToPlayer : MonoBehaviour {

	public Transform targetPosition;
	private int damp = 5; 
	private Quaternion rotationAngle;
	
	void Update ()
	{
		if ( targetPosition ) 
		{
			rotationAngle = Quaternion.LookRotation ( targetPosition.position - transform.position); 
			transform.rotation = Quaternion.Slerp ( transform.rotation, rotationAngle, Time.deltaTime * damp);  
		}
	}

}
