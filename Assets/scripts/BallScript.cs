using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rig;

    public float minXSpeed = 2.0f;
    public float maxXSpeed = 2.5f;

    public float minYSpeed = 0.8f;
    public float maxYSpeed = 1.2f;

    public ControllerScript controller;

    public float diffMultiplier = 1.3f;

    public float maxXVel = 10.0f;
    public float maxYVel = 10.0f;

    private int maxMultX = 1;
    private int maxMultY = 1;

    private bool speedMax = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<ControllerScript>();
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(
            Random.Range(minXSpeed, maxXSpeed)*(Random.value > 0.5f ?-1:1),
            Random.Range(minYSpeed, maxYSpeed)* (Random.value > 0.5f ? -1 : 1)
            
            );
    }

    public void slowDown(int dir)
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(
            Random.Range(minXSpeed/4, maxXSpeed/4) * dir,
            Random.Range(minYSpeed/4, maxYSpeed/4) * (Random.value > 0.5f ? -1 : 1)
            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("p1score"))
        {
            controller.player1Score();
            Destroy(gameObject);
        }

/*        if (collision.CompareTag("p2score"))
        {
            controller.player2Score();
            Destroy(gameObject);
        }
*/
        if (collision.CompareTag("bounds"))
        {
            //if we hit the top bound
            if (collision.transform.position.y > transform.position.y && rig.velocity.y > 0)
            {
                rig.velocity = new Vector2(
                    rig.velocity.x,
                    -rig.velocity.y
                    );
            }
            // if we hit the bottom bound
            if (collision.transform.position.y < transform.position.y && rig.velocity.y < 0)
            {
                rig.velocity = new Vector2(
                    rig.velocity.x,
                    -rig.velocity.y
                    );
            }
        }
        else if (collision.CompareTag("paddle"))
        {
            //if we hit the left paddle
            /*if (collision.transform.position.x < transform.position.x && rig.velocity.x < 0)
            {*/
            rig.velocity = new Vector2(
                rig.velocity.x * -diffMultiplier,
                rig.velocity.y
                );

            if (rig.velocity.x < 0)
            {
                maxMultX = -1;
            }
            else
            {
                maxMultX = 1;
            }

            if (rig.velocity.y < 0)
            {
                maxMultY = -1;
            }
            else
            {
                maxMultY = 1;
            }
            Debug.Log(rig.velocity.x);

            if (rig.velocity.x > maxXVel || rig.velocity.x < -maxXVel)
            {
                Debug.Log("max");
                rig.velocity = new Vector2(
                maxXVel * maxMultX,
                rig.velocity.y
                );
            }
            if (rig.velocity.y > maxYVel || rig.velocity.y < -maxYVel)
            {
                rig.velocity = new Vector2(
                rig.velocity.x,
                maxYVel * maxMultY
                );
            }
        }
        //if we hit the right paddle
        if (collision.transform.position.x > transform.position.x && rig.velocity.x > 0)
        {
            rig.velocity = new Vector2(
                rig.velocity.x * -diffMultiplier,
                rig.velocity.y
                );
        }
    }
   

    // Update is called once per frame
    void Update()
    {
/*        if (transform.position.x >= 3.2)
        {
            controller.player1Score();
            Destroy(gameObject);
        }*/
        if (transform.position.x <= -3.2)
        {
            controller.player2Score();
            Destroy(gameObject);
        }

        /*if (rig.velocity.x > maxXVel)
        {
            speedMax = true;

        }
        else
        {
            speedMax = false;
        }
        if (rig.velocity.x < 0)
        {
            if (speedMax)
            {
                rig.velocity = new Vector2(
            -maxXVel,
            rig.velocity.y
            );
            }
        }
        else
        {
            if (speedMax)
            {
                rig.velocity = new Vector2(
            maxXVel,
            rig.velocity.y
            );
            }
        }*/

    }
}
