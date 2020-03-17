using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Dit script is verantwoordelijk voor alle bewegingen van de speler. De snelheid en de input van de knoppen die ervoor zorgen dat je kan 
 * bewegen.
 */
public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f; //hier kan je de snelheid van de speler aanpassen. Hoe hoger, hoe sneller de speler zal bewegen.
    
    
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
    }
    
}
