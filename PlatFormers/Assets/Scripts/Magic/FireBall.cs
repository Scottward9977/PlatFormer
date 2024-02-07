using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fireball;
    private Vector2 spwanpoint;
    public GameObject Player;
    public PlayerMov mov;
    private GameObject afterspwan;
    private Rigidbody2D rb;
    // Update is called once per frame

    private void Start()
    {
        
    }
    void Update()
    {
        if (fireball != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (mov.Fliped)
                {
                    spwanpoint.x = Player.transform.position.x - 1;
                    spwanpoint.y = Player.transform.position.y;
                    afterspwan = Instantiate(fireball, spwanpoint, Quaternion.identity);
                    rb = afterspwan.GetComponent<Rigidbody2D>();
                    addforceleft();

                }
                else
                {
                    spwanpoint.x = Player.transform.position.x + 1;
                    spwanpoint.y = Player.transform.position.y;
                    afterspwan = Instantiate(fireball, spwanpoint, Quaternion.identity);
                    rb = afterspwan.GetComponent<Rigidbody2D>();
                    addforceright();
                }

            }
        }
    }
    private void addforceright()
    {
        Vector2 force;
        force.x = 10;
        force.y = 0;
        rb.velocity = force;   
    }
    private void addforceleft()
    {
        Vector2 force;
        force.x = -10;
        force.y = 0;
        rb.velocity = force;
    }
}
