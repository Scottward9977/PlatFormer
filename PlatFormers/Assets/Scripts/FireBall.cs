using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fireball;
    private Vector2 spwanpoint;
    public GameObject Player;
    public PlayerMov mov;
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

                }
                else
                {
                    spwanpoint.x = Player.transform.position.x + 1;
                    spwanpoint.y = Player.transform.position.y;
                }
                Instantiate(fireball, spwanpoint, Quaternion.identity);
            }
        }
    }
}
