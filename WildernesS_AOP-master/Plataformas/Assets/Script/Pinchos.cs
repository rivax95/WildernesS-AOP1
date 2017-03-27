using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{

    PlayerData restarvida = new PlayerData();


    public bool yaPinchado = false;
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
        if (other.tag == "Player" && !yaPinchado)
        {
            yaPinchado = true;
            other.GetComponent<PlayerData>().vidas-=1;
            this.GetComponent<AudioSource>().Play();

            StartCoroutine(ContadorPinchado());
        }
    
        //if ((other.tag == "player") && (restarvida.muerte == true))
        //{
        //    other.gameObject.transform.position = new Vector3(1, -3, 0);
        //}
    }

    IEnumerator ContadorPinchado()
    {
        yield return new WaitForSeconds(1);
        yaPinchado = false;
    }

}