using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour {

    public Vector3 posicion;
    public float cantbajada = 3.0f;
    public float canttotal;
    public bool funciona = false;
    float timer = 0.05f;
    bool termino = true;
   // float delay = 1f;
    // Use this for initialization
    void Start()
    {
        posicion = this.gameObject.GetComponent<Transform>().position;
        canttotal = this.gameObject.GetComponent<Transform>().position.y - cantbajada;
    }

    // Update is called once per frame
    void Update()
    {

        if (funciona == true)
        {
            descenso();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player")&& (termino == true))
        {
            funciona = true;
        }
    }

    public void descenso()
    {
        if (funciona == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                transform.position += transform.position = new Vector3(0f, -1f, 0f) * 10 * Time.deltaTime;

                if (this.gameObject.GetComponent<Transform>().position.y < canttotal)
                {
                    funciona = false;
                    Destroy(this.gameObject,0.01f);
                }
                termino = false;

            }
        }
    }
}
