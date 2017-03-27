using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensor : MonoBehaviour {
    public Vector3 posicion;
    public float cantbajada = 2.0f;
    public float canttotal;
    public bool funciona = false;

    // Use this for initialization
    void Start () {
        posicion = this.gameObject.GetComponent<Transform>().position;
        canttotal = this.gameObject.GetComponent<Transform>().position.y - cantbajada;
    }
	
	// Update is called once per frame
	void Update () {

        if (funciona == true)
        {
            descenso();
        }
        
	}
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            funciona = true;
        }
    }

    public void descenso()
    {
        if (funciona == true)
        {
            transform.position += transform.position = new Vector3(0f, -1f, 0f) * 1 * Time.deltaTime;

            if (this.gameObject.GetComponent<Transform>().position.y < canttotal)
            {
                funciona = false;
            }
        }
    }
}

