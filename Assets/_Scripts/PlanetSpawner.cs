using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planets; // Array de prefabs de planetas
    public float minInstantiateX = -7f;
    public float maxInstantiateX = 7f;
    public float instantiateY = 5.5f;
    public float spawnInterval = 20f;
    
    
    void Start()
    {
        InvokeRepeating("InstantiatePlanet", 0f, spawnInterval);
    }

    void InstantiatePlanet()
    {
        Vector3 planetPos = new Vector3(Random.Range(minInstantiateX, maxInstantiateX), instantiateY);
        int randomIndex = Random.Range(0, planets.Length);
        Instantiate(planets[randomIndex], planetPos, Quaternion.identity);
    }
    
    

}
