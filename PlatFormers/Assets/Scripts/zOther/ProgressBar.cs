using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxFill;
    public float currentFill;
    public Image mask;
 
    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();

        if(currentFill > maxFill )
        {
            currentFill = maxFill;
        }

    }
    void GetCurrentFill()
    {
        float fillAmount = currentFill/maxFill;
        mask.fillAmount = fillAmount;
    }
}
