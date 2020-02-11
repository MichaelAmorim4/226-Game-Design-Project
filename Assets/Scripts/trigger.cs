using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    //conlition detecition
    void OnTriggerEnter2D(Collider2D other){
        PlayerController pc = other.GetComponent<PlayerController>();
        Debug.Log("open");
        // The if statemwnt below shows when Bukiki touch the door, the door will open
        //if(pc != null){


    }
}
