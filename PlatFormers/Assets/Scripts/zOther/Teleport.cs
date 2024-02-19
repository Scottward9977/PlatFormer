using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Teleport : MonoBehaviour
{
    //all of the script was writen but Scott
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject trapTarget;
    public Teleport tel;
    public int numberTelort = 0;
    public MagicMissisal  missisal;
    public HealthRegen healthRegen;
    // Start is called before the first frame update

    private void Start()
    {
        // turns off player script 
        missisal.enabled = false;
        healthRegen.enabled = false;

    }
    private void Update()
    {
        // turns on scripts as needed 
        if (tel.numberTelort >= 2) missisal.enabled = true;
        if(tel.numberTelort >= 3) healthRegen.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // telipoers player on collistion 
        GameObject collistion = collision.gameObject;
        if (collistion.CompareTag("Player"))
        {
            tel.numberTelort += 1;
            player.transform.position = trapTarget.transform.position;
        }
    }
}
