using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float VelMov;
    public float Origvectx;
    public bool derecha = true;
    public bool Persigue = false;
    public float desplazamiento = 2.0f;
    public float desplazamientosuma;
	// Use this for initialization
	void Start () {
        Origvectx = transform.position.x;

    
    }
	
	// Update is called once per frame
	void Update () {
        VelMov = 2.0f;
        movimiento();
	}
    public void movimiento()
    {
        desplazamientosuma = Origvectx + desplazamiento;
        if (Persigue==false)
        {
           
            if (derecha == true) {
                transform.position += transform.position = new Vector3(+1f, 0f, 0f) * VelMov * Time.deltaTime;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                //animacion
                if (transform.position.x > desplazamientosuma)
                {
                    derecha = false;
                }
            }
            else
            {
                transform.position += transform.position = new Vector3(-1f, 0f, 0f) * VelMov * Time.deltaTime;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                //animacion
                if (transform.position.x < Origvectx)
                {
                    derecha = true;
                }

            }
            Debug.Log("La velocidad en la que camina el enemigo es:" + VelMov);
        }
    }
}
