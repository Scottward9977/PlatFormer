using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalloperations : MonoBehaviour
{
    //all of the script was writen but Scott
    // controlls the coliston on the fire ball 
    public GameObject fireball;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if(gameObject.CompareTag("enemy"))
        {
            Enemy en = gameObject.GetComponent<Enemy>();
            if(en != null) {en.health -= 1;}
            Destroy(fireball);
        }
    }
}
