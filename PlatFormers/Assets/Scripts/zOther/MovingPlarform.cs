using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovingPlarform : MonoBehaviour
{
    // Start is called before the first frame update
    public bool veritcal;
    public bool horizontal;
    public GameObject platform;
    public Vector2 movePointleft = Vector2.zero; 
    public Vector2 movePointRight = Vector2.zero;

    public Vector2 movePointUp = Vector2.zero;
    public Vector2 movePointDown = Vector2.zero;

    private bool movingLeft = true;
    private bool movingRight = false;

    public  bool movingUp = true;
    public  bool movingDown = false;

    public float moveDistance =5;


    void Start()
    {     
        movePointDown.x = platform.transform.position.x;
        movePointUp.x = platform.transform.position.x;
        movePointleft.y = platform.transform.position.y;
        movePointRight.y = platform.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if(horizontal)
        {
            if(movingLeft)
            {
                Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
                Vector2 newPosition = Vector2.MoveTowards(rb.position, movePointleft, moveDistance * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
            if (movingRight) 
            {
                Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
                Vector2 newPosition = Vector2.MoveTowards(rb.position, movePointRight, moveDistance * Time.deltaTime);
                rb.MovePosition(newPosition);
            }

            if(platform.transform.position.x >= movePointRight.x)
            {
                movingRight = false;
                movingLeft = true;
            }
            if (platform.transform.position.x <= movePointleft.x)
            {
                movingRight = true;
                movingLeft = false;
            }

        }
        if (veritcal)
        {
            if (movingUp)
            {
                Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
                Vector2 newPosition = Vector2.MoveTowards(rb.position, movePointUp, moveDistance * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
            if (movingDown)
            {
                Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
                Vector2 newPosition = Vector2.MoveTowards(rb.position, movePointDown, moveDistance * Time.deltaTime);
                rb.MovePosition(newPosition);
            }

            if (platform.transform.position.y >= movePointUp.y -.1)
            {
                movingUp = false;
                movingDown = true;
            }
            if (platform.transform.position.y <= movePointDown.y)
            {
                movingUp = true;
                movingDown = false;
            }

        }

    }
}
