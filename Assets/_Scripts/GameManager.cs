using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
public GameObject enemyPrefab;
public float minInstantiateX = -7f;
public float maxInstantiateX = 7f;
public float enemyDestroyTime = 10f;

void Start()
{
    InvokeRepeating("InstantiateEnemy", 1f, 1f);
    
}

void InstantiateEnemy()
{   
    Vector3 enemyPos = new Vector3(Random.Range(minInstantiateX, maxInstantiateX), 5.5f);
    GameObject enemy = Instantiate(enemyPrefab, enemyPos,Quaternion.Euler(0f,0f,180f));
    Destroy(enemy, enemyDestroyTime);
}
}
