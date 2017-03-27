using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject canvas;
	
    public void volver()
    {
      
        GameObject player = GameObject.FindWithTag("Player");
        AudioSource corazon = player.GetComponent<AudioSource>();
        player.transform.position=player.GetComponent<PlayerData>().posiciones;
        canvas.SetActive(false);
        player.GetComponent<PlayerData>().vidas = 3;
        Time.timeScale = 1;
        corazon.Stop();
    }
}
