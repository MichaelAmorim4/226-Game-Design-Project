using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other){
      PlayerController pc = other.GetComponent<PlayerController>();
      Debug.Log("open");

    }
}
