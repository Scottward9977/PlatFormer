using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements.Experimental;

public class PlayerMov : MonoBehaviour
{
    private Vector2 input;
    [SerializeField]
    private float speed = 1.0f;
    public Rigidbody2D rb;
    private Vector2 move;
    public float jump = 2f;
    public bool Fliped = false;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Fliped = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Fliped = false;
        }
        if(Fliped)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        move.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
      
        

    }
}
