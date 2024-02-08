using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerHealth : MonoBehaviour
{
    public int health = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collistion = collision.gameObject;
        if (collistion.CompareTag("attack"))
        {
            health -= 1;
        }
    }
  
    private void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

}
