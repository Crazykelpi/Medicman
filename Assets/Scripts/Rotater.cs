using UnityEngine;
using System.Collections;
/*
 * Dit script zorgt ervoor dat de papiertjes ronddraaien.
 * We raden aan om hier niets aan te passen.
 */
public class Rotater : MonoBehaviour {

	void Update(){
		transform.Rotate(new Vector3(30,30,0) * Time.deltaTime);
	}
	
}
