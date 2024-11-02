using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    public void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {   
        
        // Player Movement
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(xPos*speed*Time.deltaTime, yPos*speed*Time.deltaTime, 0);
        transform.Translate(movement);
    }
}
