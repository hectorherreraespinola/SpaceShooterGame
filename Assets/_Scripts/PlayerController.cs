using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    
    
    
    [Header("Missile Prefab")]
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public float destroyTime = 2.0f;
    

    public void Update()
    {
        PlayerMovement();
        PlayerShoot();  
    }

    void PlayerMovement()
    {

        // Player Movement
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xPos * speed * Time.deltaTime, yPos * speed * Time.deltaTime, 0);
        transform.Translate(movement);
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject gm= Instantiate(missilePrefab,missileSpawnPoint);
           gm.transform.SetParent(null);
           Destroy(gm,destroyTime);
        }
    }
}
