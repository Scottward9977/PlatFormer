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
    public float cooldownTimerbase =1;
    private float cooldownTime = 1;

    // Update is called once per frame

    private void Start()
    {
        
    }
    void Update()
    {
        if (fireball != null && cooldownTime <= 0)
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
                    cooldownTime = cooldownTimerbase;

                }
                else
                {
                    spwanpoint.x = Player.transform.position.x + 1;
                    spwanpoint.y = Player.transform.position.y;
                    afterspwan = Instantiate(fireball, spwanpoint, Quaternion.identity);
                    rb = afterspwan.GetComponent<Rigidbody2D>();
                    addforceright();
                    cooldownTime = cooldownTimerbase;
                }

            }
        }
        cooldownTime -= Time.deltaTime;
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
