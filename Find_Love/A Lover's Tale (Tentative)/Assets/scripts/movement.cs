using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour{

    public float speed;
    private Rigidbody2D rigid2D;
    public float jump;
    private int jumpsLeft = 1;
    public GameObject player;

	// Use this for initialization
	void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigid2D.velocity = new Vector2(-speed, rigid2D.velocity.y);
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && jumpsLeft > 0)
        {
            Jump();
        }
        
	}

    void Jump()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "groundTag" && jumpsLeft < 1)
        {
            jumpsLeft = 1;
        }
        
        if(collision.gameObject.tag == "deathTag")
        {
            player.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "groundTag" && jumpsLeft < 1)
        {
            jumpsLeft = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "groundTag")
        {
            jumpsLeft = 0;
        }
    }
}
