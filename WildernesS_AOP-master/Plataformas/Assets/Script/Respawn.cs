using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    SpriteRenderer opacidad; 

    public bool respawn = true;

    
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
    }
 public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("fuera");
        opacidad = GetComponent<SpriteRenderer>(); 
        if ((other.tag == "Player")&&(respawn==true))
        {

            other.gameObject.GetComponent<PlayerData>().posiciones = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z);
            this.GetComponent<AudioSource>().Play();
            respawn = false;
          opacidad.sprite = null; 

        }
    }
}