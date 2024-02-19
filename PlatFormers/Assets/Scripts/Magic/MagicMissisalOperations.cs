using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicMissisalOperations : MonoBehaviour
{
    //all of the script was writen but Scott
    // class is meant for the storing and keeping track of each bullets information individualy 
    public Vector2 closenessThreshold = new Vector2(1f, 1f); 
    public GameObject closestObj;
    public bool dead = false;


    private void Update()
    {
       
        if (closestObj != null)
        {
            
            float distance = Vector2.Distance(transform.position, closestObj.transform.position);

            
            if (distance <= closenessThreshold.x || distance <= closenessThreshold.y)
            {
                
                Enemy en = closestObj.GetComponent<Enemy>();

                
                if (en != null)
                {
                    en.health -= 1; 
                }

               if(en.health <= 0) { dead = true; }
                
            }
        }

    }

    
            
}
