using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicMissisalOperations : MonoBehaviour
{
    public Vector2 clossest = new Vector2(200f, 200f);
    public GameObject closestObj;
    public bool dead = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collgameObject = collision.gameObject;
        if (collgameObject.CompareTag("enemy"))
        {
            Enemy en = collgameObject.GetComponent<Enemy>();
            if (en != null) { en.health -= 1; }
            dead = true;
            
        }
    }
}
