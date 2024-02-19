using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player"); 
            PlayerHealth heatlh = player[0].GetComponent<PlayerHealth>();
            heatlh.killCount += 1;
            Destroy(gameObject);
        }
    }
}
