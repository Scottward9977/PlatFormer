using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Jump");
        rb.velocity = move * speed;

    }
}
