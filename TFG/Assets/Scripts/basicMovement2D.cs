using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement2D : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.
    public float jump;                //Floating point variable to store the player's movement speed.

    public float groundDetectHeight;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private BoxCollider2D col2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Start is called before the first frame update
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        //Store the current vertical input in the float moveVertical.
        float moveVertical = rb2d.velocity.y;//Input.GetAxis("Vertical") * speed;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.velocity = movement;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }
    }

    bool IsGrounded()
    {
        Vector2 rightCorner = new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2));
        Vector2 leftCorner = new Vector2(transform.position.x + (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2) - groundDetectHeight);

        Debug.Log(Physics2D.OverlapArea(rightCorner, leftCorner, groundLayer));

        return Physics2D.OverlapArea(rightCorner, leftCorner, groundLayer);
    }
}
