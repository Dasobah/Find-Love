using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionEffects : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag" && player.GetComponent<movement>().GetJumpsLeft() < 1)
        {
            player.GetComponent<movement>().SetJumpsLeft(1);
        }

        if (collision.gameObject.tag == "deathTag")
        {
            player.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag" && player.GetComponent<movement>().GetJumpsLeft() < 1)
        {
            player.GetComponent<movement>().SetJumpsLeft(1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag")
        {
            player.GetComponent<movement>().SetJumpsLeft(0);
        }
    }

}
