using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour{

    public float speed;
    private Rigidbody2D rigid2D;
    public float jump;
    private int jumpsLeft;
    public GameObject player;

	// Use this for initialization
	void Start () {
        jumpsLeft = 1;
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

    public int GetJumpsLeft()
    {
        return jumpsLeft;
    }

    public void SetJumpsLeft(int num)
    {
        jumpsLeft = num;
    }

}
