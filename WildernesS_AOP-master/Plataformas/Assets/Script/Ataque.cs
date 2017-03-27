using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    //delcaracion de variables
    public int daño = 1;
    public List<string> enemigos = new List<string>();
    public bool derecha = true;
    public bool puedeatacar = false;
    public LayerMask rayCastDetect;
    public float culdown = 0.5f;
    // NOTE por la cara
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direccion();

    }


    public void rallo()
    {

        //1.- Mira bien la diferencia entre los parametros de Debug.Drawray y Physics2D.Raycast
        Debug.DrawRay(transform.position, transform.right * (derecha ? 1 : -1) * 0.6f, Color.red, 0);
        RaycastHit2D obj = Physics2D.Raycast(transform.position, transform.right * (derecha ? 1 : -1), 0.6f, rayCastDetect);

        //Podemos filtrar lo que choca con el rayo con las capas físicas (layer y layerMask)

        //Como raycast no siemrpe va a detectar algo, hay que comprobar primero si el rayo choco con algo
        if (obj)
        {
       
            //Segun lo que detecte el rayo (clasificacion por TAGs)
            switch (obj.collider.tag)
            {
                case "enemy":
                    Debug.Log("Enemigo enfrente");
                    GameObject enemy = obj.collider.gameObject;
                    if ((Input.GetKeyDown(KeyCode.Mouse0))) //instrucciones
                    {
                        enemy.GetComponent<Enemigo>().vida -= daño;
                        //TODO se ejecuta una animacion
                        //TODO tiempo de espera de refresco del ataque
                    }


                    break;
                case "caja":
                    ;
                    Debug.Log("Colision detectada con caja");

                    if ((Input.GetKeyDown(KeyCode.Mouse0))) //instrucciones
                    {
                        obj.collider.GetComponent<SpriteEstados>().vidas--;
                        //TODO se ejecuta una animacion de ataque
                    }
                    break;
            }
        }
        else
        {
            puedeatacar = false;
        }

    }
    public void direccion()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            derecha = true;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            derecha = false;
        }
        rallo();
    }

}