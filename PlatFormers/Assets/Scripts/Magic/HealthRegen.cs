using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public int healthRegen;
    private int healthRegenMax;
    [SerializeField] PlayerHealth healthscript;
    void Start()
    {
        healthRegenMax = healthscript.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            heal();
        }
    }
    private void heal()
    {
        healthscript.health += healthRegen;
        if(healthscript.health > healthRegenMax ) healthscript.health = healthRegenMax;
    }
}
