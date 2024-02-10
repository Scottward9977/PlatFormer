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

    private bool movingLeft = true;
    private bool movingRight = false;





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(veritcal)
        {
            if(movingLeft)
            {
                movePoint.y = movePointleft.y;
                Rigidbody2D rb = 
                Vector2 newPosition = Vector2.MoveTowards(rb.position, movePoint, MoveDistance * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
                
        }
        
    }
}
