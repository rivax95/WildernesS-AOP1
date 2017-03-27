using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    // si una variable es publica se podra modificar desde otro script si es privada no, si no se pone nada delante de
    //la variable se entiende que la variable es privada

    //Declaracion de Variables
    public Vector3 posiciones;
    public Respawn resp;
    public int monedas = 0;
    public float Pulsos = 100.0f;
   public int vidas=3;
    public int chapa = 0;
    public TextMesh vidast;
    float temptime = 0.0f;
    public TextMesh chapat;
    bool recibirdano = false;
   public Color32 rojo = new Color32(255,0,0,255);
   public Color32 blanco = new Color32(255,255,255,255);
    public GameObject muerteUI;
    void Start() 
   {
        actualizavida();
        resp = GameObject.Find("logo0").GetComponent<Respawn>();
    }
    //_______________________________________________
    public void actualizacolor(bool value) // nuevo color
    {
        if (recibirdano == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color =rojo;
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color =blanco;
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }
    //___________________________________________________
    public void meduele(int value) // daño
    {
        if (recibirdano == true) return;
         
        vidas = vidas - value;
        recibirdano = true;

    }
    //____________________________________________________
    void Update()
    {

        actualizacolor(recibirdano);
        if (recibirdano == true)
        {
            temptime = temptime + 1 * Time.deltaTime;
            if (temptime >= 0.5f)
            {
                temptime = 0f;
                recibirdano = false;
            }
        }
        actualizavida();
    }
    //_____________________________________________
     void actualizavida()
    {
        vidast.text = vidas.ToString();
        chapat.text = chapa.ToString();
        if (vidas <= 0)
        {
            muerteUI.SetActive(true);
            Time.timeScale = 0; // velocidad juego 0
        }
        if (vidas == 1)
        {
            this.GetComponent<AudioSource>().Play();
        }


    }

}

