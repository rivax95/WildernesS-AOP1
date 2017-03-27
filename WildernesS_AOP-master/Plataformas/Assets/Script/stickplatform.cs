using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickplatform : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player") 
        {
            coll.transform.SetParent(this.gameObject.transform);
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            coll.transform.SetParent(null);
        }
    }

}
