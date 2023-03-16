using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float yInput;
    public float bound;

    public int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        yInput = Input.GetAxis("Vertical" + playerIndex.ToString());
        if (yInput != 0)
        {
            rig.velocity = new Vector2(0, yInput * moveSpeed);
        }
        else
        {
            rig.velocity = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // bind to the screen
        if (transform.position.y >= bound)
        {
            transform.position = new Vector3(transform.position.x, bound, transform.position.z);
        }
        if (transform.position.y <= -bound)
        {
            transform.position = new Vector3(transform.position.x, -bound, transform.position.z);
        }
    }

    public void changeSize(int point)
    {
        
        if (point == playerIndex)
        {
            transform.localScale = new Vector3(1, transform.localScale.y - .09f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y + .09f, 1);
        }
    }

}
