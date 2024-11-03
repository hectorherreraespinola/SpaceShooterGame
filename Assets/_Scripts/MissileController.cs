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
}
