using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos2 : MonoBehaviour {
    public int vidas = 1;
    GameObject player;
    bool derecha;
    public float rango = 0.5f;
    public LayerMask raycastdetected; // NOTE CONFIGURAR EN UNITY
    RaycastHit2D detectde;
    RaycastHit2D detectiz;
    Vector2 objetibo;
    public float distancia_ataque=0.5f;
    public int dano = 1;
    public bool quieto = false;
    public float culdown = 0.5f;
    public float VelMov = 1.5f;
    MovimientoEnemigo mov;
    bool golpea = false;
    Vector2 quietov2;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        mov = this.gameObject.GetComponent<MovimientoEnemigo>(); // NOTE puede que no lo detecte si no lo tiene el script por lo que tengo que si el enemigo es estatico va a tirar error Null referent....
	}
	
	// Update is called once per frame
	void Update () {
        muerte();
         quietov2 = transform.position;
        detectiz = Physics2D.Raycast(transform.position, transform.right * (-1),rango,raycastdetected);
         detectde = Physics2D.Raycast(transform.position, transform.right * (1), rango, raycastdetected);
        Debug.DrawRay(transform.position, transform.right * (-1) * rango, Color.white, 0);
        Debug.DrawRay(transform.position, transform.right * (1) * rango, Color.white, 0);
        objetibo = player.gameObject.transform.position;
        perseguir();
    }
    public void perseguir()
    { // NOTE mirar bien el script de movimiento que no interrumpa a este ni viceversa. *Mirado y corregio a falta de testearlo|26/03/2017 12:00|
        if (detectde.collider.tag == "Player")
        {
           
            golpea = true;
            mov.Persigue = true;
            Debug.Log("Enemigo detecta a Player");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(+1f, 0f, 0f) * VelMov * Time.deltaTime;
            Debug.Log(detectde.distance + " Distancia del enemigo al personaje");
            if (detectde.distance < distancia_ataque) // ya tira
            {
                quieto = true;
                if (quieto==true)
                {
                    transform.position = quietov2;
                }
               
                Debug.Log("Enemigo ataca");
                //TODO ejecuta animacion
                 if (!IsInvoking("ferCooldown")) // NOTE MIRAR Repasado con fernando 27/03/2017
                {
                    player.GetComponent<PlayerData>().vidas -= dano;
                    Invoke("ferCooldown", 2.0f);
                }
            }
        }
        else
        {
            quieto = false;
            mov.Persigue = false;
        }
    }
    public void actualizarestado()
    {

        if (player.transform.position.x > this.gameObject.transform.position.x)
        {
            derecha =true;
        }
        else
        {
            derecha = false;
        }
    }
    public void muerte()
    {
        if (vidas == 0)
        {
            // TODO AUDIO
            //TODO ANIMACION
            Destroy(this.gameObject);
        }
    }

    void ferCooldown()
    {
        return;
    }
   
}
