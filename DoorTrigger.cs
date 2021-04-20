using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject Door;
     private void OnTriggerEnter(Collider other) {
         if (other.gameObject.name == "theBoss") {
             Door.GetComponent<Animation>().Play("Door_Open");             
         }         
     }

     private void OnTriggerExit(Collider other) {
         if (other.gameObject.name == "theBoss") {
             Door.GetComponent<Animation>().Play("Door_Close");             
         }
     }
}
