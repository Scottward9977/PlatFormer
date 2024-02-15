using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Public Variables")]
    public int moveSpeed;
    public int jumpSpeed;
    public bool isGrounded;
    public string movementState;

    private Rigidbody2D playerRB;
    private float verticalVelocity = 0;
    private float horizontalVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        horizontalVelocity = inputX * moveSpeed;
        bool inputSpace = Input.GetKey(KeyCode.Space);
        if (inputSpace && isGrounded)
        {
            verticalVelocity = jumpSpeed;
        } else
        {
            verticalVelocity = 0;
        }

        if(isGrounded)
        {
            playerRB.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        } else
        {
            playerRB.velocity = new Vector2(horizontalVelocity, playerRB.velocity.y);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Collidable"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Collidable"))
        {
            isGrounded = false;
        }
    }
}
