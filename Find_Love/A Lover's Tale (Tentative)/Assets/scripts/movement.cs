using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rigid2D;
    public float jump;
    private int jumpsLeft = 1;
    public GameObject player;

    public float maxTime;
    public float minTime;

    // Use this for initialization
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float start = Time.time;

        rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigid2D.velocity = new Vector2(-speed, rigid2D.velocity.y);
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && jumpsLeft > 0)
        {
            Jump();
        }
        //stopping the jump
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space) || maxTime < Time.time - start)
        {
            if (rigid2D.velocity.y > 0F)
            {
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0.1F);
            }
        }
    }

    void Jump()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag" && jumpsLeft < 1)
        {
            jumpsLeft = 1;
        }

        if (collision.gameObject.tag == "deathTag")
        {
            player.SetActive(false);
            GetComponent<respawn>().setDead();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag" && jumpsLeft < 1)
        {
            jumpsLeft = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag")
        {
            jumpsLeft = 0;
        }
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
