using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement3D : MonoBehaviour
{
    public gunRotation _gun;
    public Animator _animator;
    public SpriteRenderer _sprite;
    public float speed;                //Floating point variable to store the player's movement speed.
    /*
    public float jump;
    public float groundDetectHeight;
    [SerializeField] private LayerMask groundLayer;
    */

    private Rigidbody rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    //private BoxCollider col;        //Store a reference to the Rigidbody2D component required to use 2D Physics.    

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody>();
        //col = GetComponent<BoxCollider>();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Jump();
    }

    void Move()
    {
        float moveX = 0.0f;
        float moveZ = 0.0f;

        if (!gm.isControllerMode)
        {
            //Store the current horizontal input in the float moveHorizontal.
            moveX = Input.GetAxis("Horizontal") * speed;
            moveZ = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            //Store the current horizontal input in the float moveHorizontal.
            moveX = Input.GetAxis("Horizontal_Joy") * speed;
            moveZ = Input.GetAxis("Vertical_Joy") * speed;
        }

        _animator.SetBool("moving", moveX != 0f || moveZ != 0f);

        if (_gun.getGunDir().x <= 0)
            _sprite.flipX = true;
        else if(_gun.getGunDir().x > 0)
            _sprite.flipX = false;
        //Store the current vertical input in the float moveVertical.

        float moveY = rb.velocity.y;

        _animator.SetBool("backwards", (moveX > 0f &&  _sprite.flipX) || (moveX <= 0f && !_sprite.flipX));
        //Use the two store floats to create a new Vector2 variable movement.
        Vector3 movement = new Vector3(moveX, moveY, moveZ);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb.velocity = movement;
    }

    /*
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }

    bool IsGrounded()
    {
        bool check = Physics.Raycast(transform.position, Vector3.down, groundDetectHeight, groundLayer);

        //Debug.Log(check);

        return check;
    }
    */
}
