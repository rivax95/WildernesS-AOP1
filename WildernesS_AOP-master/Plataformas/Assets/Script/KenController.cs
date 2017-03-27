using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenController : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        //getcomponente
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("dash");
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("hadouken");
            
        }
    }
}
