using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

    public bool dead;
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
        }

	}

    void setDead()
    {

    }
}
