using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

    public static bool dead;
    public GameObject player;
    public Vector2 spawnLocation;

	// Use this for initialization
	void Start () {
        spawnLocation = new Vector2(player.transform.position.x, player.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = spawnLocation;
            player.SetActive(true);
            if (dead)
            {
                dead = false;
            }
        }
        if(dead && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))) { 
            player.transform.position = spawnLocation;
            player.SetActive(true);
            dead = false;
        }
	}

    public static void setDead()
    {
        dead = true;
    }
}