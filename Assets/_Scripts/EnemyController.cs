using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float enemySpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
    
    void EnemyMovement()
    {
        transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
    }
}
