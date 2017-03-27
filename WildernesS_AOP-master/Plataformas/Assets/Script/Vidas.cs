using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour {


    bool sefue = true;
    SpriteRenderer opacidad;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        int lavida = other.GetComponent<PlayerData>().vidas; // me sirve para contralar la vida desde aqui pero este no lo voy a usar fuera de aqui.
        opacidad = GetComponent<SpriteRenderer>();
        int maxvida = 3;
        if ( (other.tag == "Player") && (sefue == true) && (lavida < maxvida) )
        {
            this.GetComponent<AudioSource>().Play();
            other.GetComponent<PlayerData>().vidas += 1;
            opacidad.sprite = null;
            sefue = false;
            this.GetComponent<AudioSource>().Play();
        }
    }
}