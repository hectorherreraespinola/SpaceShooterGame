using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] enemies;
    public float minInstantiateX = -7f;
    public float maxInstantiateX = 7f;
    public float enemyDestroyTime = 10f;

    [Header("Particle Effect")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
    }

    void InstantiateEnemy()
    {
        Vector3 enemyPos = new Vector3(Random.Range(minInstantiateX, maxInstantiateX), 5.5f);
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[randomIndex], enemyPos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy, enemyDestroyTime);
    }
}
