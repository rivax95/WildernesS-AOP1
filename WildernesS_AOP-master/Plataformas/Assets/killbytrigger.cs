using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killbytrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) // cuando se entre en este trigger(lo que queremos es que se destrulla el obj)
    {
      //  if (other.tag == "Player")
        Destroy(other.gameObject); // destrulle el gameobject
    }

}
