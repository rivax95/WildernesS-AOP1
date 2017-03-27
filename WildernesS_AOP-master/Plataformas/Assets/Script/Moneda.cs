using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour {
    // istanciacion
    PlayerData sumamoneda = new PlayerData();
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // este evento se ejecuta cuando un colider (other) choca conb el triggr de
    // este objeto
    // el parametro "other" representa a este objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //sumamoneda.monedas = sumamoneda.monedas++;

            other.GetComponent<PlayerData>().monedas++;
            this.GetComponent<AudioSource>().Play();
         //   FindObjectOfType<PlayerData>().monedas += 1;
            Destroy(this.gameObject,3);
           
        }
    }
}
