using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour {
    //Declaracion de variables
    float timer = 1f;
    float delay = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
  //        gameObject.SetActive(false); // para descativar objetos
    //      light.enabled = true;
      //    Instantiate(brick, new Vector3(x, y, 0), Quaternion.identity);

        // Temporizador

}
    void temporizador()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
          
        }
    }
 
}
