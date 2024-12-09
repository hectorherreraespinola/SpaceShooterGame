using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public float planetSpeed = 1.0f;
    
    void Update()
    {
        transform.Translate(Vector3.down * planetSpeed * Time.deltaTime);
    }
}
