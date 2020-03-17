using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Dit script zorgt ervoor dat wanneer je te dicht bij slender komt je naar hem draait en een jumpscare krijgt.
 * Pas hier niets aan.
 */
public class TurnToSlender : MonoBehaviour
{
    public static float distance;
    public Transform targetPosition;
    public Renderer slender;
    private Quaternion rotationAngle;
    private int damp = 5;


    void Update()
    {
        distance = Vector3.Distance(transform.position, slender.transform.position);
        if(distance<=5f)
        {
            if (targetPosition) 
            {
                rotationAngle = Quaternion.LookRotation(targetPosition.position - transform.position); 
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp);  
            }
        }
        
    }
}
