using System.Collections;
using System.Collections.Generic;
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
    public float moveDistance =5;




    void Start()
    {
        movePointDown.x = 0f;
        movePointUp.x = 0f;
        movePointleft.y = 0f;
        movePointRight.y = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(veritcal)
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


        }

    }
}
