using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    //all of the script was writen but Scott
    // destorys the enemy after a set time 
    public float timer = 3f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
