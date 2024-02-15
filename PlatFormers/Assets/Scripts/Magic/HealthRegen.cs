using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public int healthRegen;
    public int healthRegenMax;
    public float maxCoolDown;
    public float currentCoolDown;
    [SerializeField] public ProgressBar progressBar;
    [SerializeField] PlayerHealth healthscript;
    void Start()
    {
        healthRegenMax = healthscript.health;
        progressBar.currentFill = currentCoolDown;
        progressBar.maxFill = maxCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && currentCoolDown >= 5f)
        {
            heal();
        }
        progressBar.currentFill = currentCoolDown;
        currentCoolDown += Time.deltaTime;
    }
    private void heal()
    {
        healthscript.health += healthRegen;
        if(healthscript.health > healthRegenMax ) healthscript.health = healthRegenMax;
        currentCoolDown = 0;
    }
}
