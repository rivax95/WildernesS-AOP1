using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    // Declaracin de variables
    public estado tipoestado;
     public float VelMov =1.5f;
    public float MaxDist = 5.0f;
    public float MinDist = 0.0f;
    public GameObject player;
    public int danoenemigo = 1;
    public int lado = 0;
    public LayerMask raycastdetect;
    public int vida = 1;
    public float culdown = 1.0f;
 public   MovimientoEnemigo mov;
  
    // Use this for initialization
    void Start () {
       player = GameObject.FindWithTag("Player");// para almecenar a player y extraer de el lo que me salga del churro   
}

    // Update is called once per frame

    void Update()
    {
        mov = GetComponent<MovimientoEnemigo>();
        muerte();
        actualizarestado();
        Debug.Log("Vidas del Enemigo:" + vida);
        Vector3 PosEne = transform.position;
        Vector3 PosPlayer = GameObject.Find("CharacterRobotBoy").GetComponent<Transform>().position;
        float distancia = Vector3.Distance(PosEne, PosPlayer);

        RaycastHit2D detect = Physics2D.Raycast(transform.position, transform.right * (lado), 0, 4, raycastdetect); //aki tiro el rallo (pa lante)"depende de lado"
        Debug.DrawRay(transform.position, transform.right * (lado) * 0.6f, Color.blue,0); // dibujame el rallo
        Debug.Log(detect.collider.tag);
        //_____________________________________________________________
        if ((distancia >= MinDist) && (distancia <= MaxDist))
        {
            mov.Persigue = true; //
            if (tipoestado == estado.derecha)
            {
                Vector3 objetivo = player.gameObject.transform.position;
                transform.position += new Vector3(+1f, 0f, 0f) * VelMov * Time.deltaTime;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                if (detect.collider.tag == "Player")
                {
                    Debug.Log("COL enemy detect derecha");
                    //TODO EJECUTA ANIMACION
                    player.GetComponent<PlayerData>().vidas -= danoenemigo;
                    this.GetComponent<AudioSource>().Play();
                    StartCoroutine(ContadorGolpeado()); // tiempo de espera del golpeo

                }
            }
            if (tipoestado == estado.izquierda)
            {
                Vector3 objetivo = player.gameObject.transform.position;
                transform.position += new Vector3(-1f, 0f, 0f) * VelMov * Time.deltaTime;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                   if (detect.collider.tag == "Player")
                {
                    Debug.Log("COL enemy detect izquierda");
                    //TODO EJECUTA ANIMACION
                    player.GetComponent<PlayerData>().vidas -= danoenemigo;
                    this.GetComponent<AudioSource>().Play();
                    StartCoroutine(ContadorGolpeado()); // tiempo de espera del golpeo
                    
                }
            }
        }
        else //
        {
            mov.Persigue = false; //
        }
    }
    
    public void actualizarestado()
    {

        if (player.transform.position.x < this.gameObject.transform.position.x)
        {
            lado = -1;
            tipoestado = estado.izquierda;
        }
        if (player.transform.position.x > this.gameObject.transform.position.x)
        {
            lado = 1;
            tipoestado = estado.derecha;
        }
    }
   
    public void muerte()
    {
        if (vida == 0)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator ContadorGolpeado()
    {
        yield return new WaitForSeconds(culdown);
        
    }

}
public enum estado
{
    derecha, izquierda
}