using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapa : MonoBehaviour
{
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
        opacidad = GetComponent<SpriteRenderer>();
        if ((other.tag == "Player")&&(sefue==true))
        {
            this.GetComponent<AudioSource>().Play();
            other.GetComponent<PlayerData>().chapa += 1;
            opacidad.sprite = null;
            sefue = false;
            this.GetComponent<AudioSource>().Play();
        }
    }
}