using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 cameraPosition = new Vector3();

        cameraPosition.z = -10;
        cameraPosition.x = Player.transform.position.x;
        cameraPosition.y = Player.transform.position.y;

        this.gameObject.transform.position = cameraPosition;
        if (this.Player)
        {
        }
	}
}
