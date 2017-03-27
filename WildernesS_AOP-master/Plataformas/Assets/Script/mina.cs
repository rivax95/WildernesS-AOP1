using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mina : MonoBehaviour {
    public bool derechaa = false;
    GameObject player;
    public bool activado;
    public float veldesp = 0.5f;
    Rigidbody2D rigplayer;
    public int radio = 170;
    float timer = 0.3f;
    bool trijer = false;
    

    private void Start()
    {
        activado = true;
    }
    private void Update()
    {
        player = GameObject.FindWithTag("Player");
        derechaa = player.GetComponent<Ataque>().derecha;
         rigplayer= player.gameObject.GetComponent<Rigidbody2D>();
     
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if ((other.tag == "Player")&&(activado==true))
        {
            Time.timeScale = 0.1f;
            Debug.Log("BOOM" + activado);
            //TODO AUDIOO

            //other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((derechaa ? -200 : 200), +200));
           // this.gameObject.GetComponent<CircleCollider2D>().radius += radio;
            // TODO REPASAR
             //other.transform.position += other.transform.position = new Vector2((derechaa ? -40 : 40), Mathf.Lerp(player.transform.position.y,player.transform.position.y +20,Time.deltaTime+1))*veldesp*Time.deltaTime;
            activado = false;
          

           // Destroy(this.gameObject,0.001f);

        }

    }
}
