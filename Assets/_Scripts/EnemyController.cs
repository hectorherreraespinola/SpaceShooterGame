using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float enemySpeed = 1.0f;
    public float zigZagFrequency = 2.0f; // Frequency of the zig-zag movement
    public float zigZagMagnitude = 1.0f; // Magnitude of the zig-zag movement

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
    
    void EnemyMovement()
    {
        if (tag == "Enemy")
        {
            transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
        }
        else if (tag == "Enemy2")   
        {
            float zigZag = Mathf.Sin(Time.time * zigZagFrequency) * zigZagMagnitude;
            Vector3 movement = new Vector3(zigZag, enemySpeed*Time.deltaTime, 0);
            transform.Translate(movement);
        }
        else if (tag == "Enemy3")
        {
            // Enemy3 movement
        }
        {
            
        }
    }
}
