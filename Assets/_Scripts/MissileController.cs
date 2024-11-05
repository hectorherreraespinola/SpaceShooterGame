using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
 public float missileSpeed = 30.0f;
 
 void Update()
 {
  transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);
 }

 private void OnCollisionEnter2D(Collision2D collision)
 {
  if (collision.gameObject.tag == "Enemy")
  {
   GameObject gm = Instantiate(GameManager.instance.explosion, transform.position,transform.rotation);
   Destroy(gm, 2.0f);
   Destroy(collision.gameObject);
   Destroy(gameObject);
   
   
  }
  
 }
}
