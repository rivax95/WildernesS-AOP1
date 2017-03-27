using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEstados : MonoBehaviour {
    //Declaracion de variables

    public Sprite roto;
    public int vidas =1;
   public GameObject vida;
    bool rotico=false;
    public Color32 transparente = new Color32(0, 0, 0, 255);

    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((vidas == 0)&&(rotico==false))
        {
            Debug.Log("CAMBIA DE ESTADO");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = roto;
            Instantiate(vida, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
            rotico = true;
            //TODO HACER QUE SE HAGA TRANSPARENTE Y MAS TARDE DESTRUIR EL OBJETO
            //this.gameObject.GetComponent<SpriteRenderer>().color = transparente;
    }
	}
}
