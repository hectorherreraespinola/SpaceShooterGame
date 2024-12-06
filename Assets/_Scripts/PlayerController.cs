using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    
    
    
    [Header("Missile Prefab")]
    public GameObject missilePrefab1;
    public GameObject missilePrefab2;
    public Transform missileSpawnPoint1;
    public Transform missileSpawnPoint2;
    public float destroyTime = 2.0f;
    
    
    public Transform muzzleSpawnPoint1;
    public Transform muzzleSpawnPoint2;
    
    
    

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
            InstantiateMissile(missilePrefab1, missileSpawnPoint1);
            InstantiateMissile(missilePrefab2, missileSpawnPoint2);
        }
    }

    void InstantiateMissile(GameObject missilePrefab, Transform missileSpawnPoint)
        {
            GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
            missile.transform.SetParent(null);
            Destroy(missile, destroyTime);
            SpawnMuzzleFlash();
        }
    
    void SpawnMuzzleFlash()
    {
        InstantiateAndDestroyMuzzleFlash(muzzleSpawnPoint1);
        InstantiateAndDestroyMuzzleFlash(muzzleSpawnPoint2);
    }

    void InstantiateAndDestroyMuzzleFlash(Transform muzzleSpawnPoint)
    {
        GameObject muzzle = Instantiate(GameManager.instance.muzzleFlash, muzzleSpawnPoint);
        muzzle.transform.SetParent(null);
        Destroy(muzzle, destroyTime);
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy"  || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3")
        {
            Destroy(this.gameObject);
            //Game OVer here
        }
    }
}
