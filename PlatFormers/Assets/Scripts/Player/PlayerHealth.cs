using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements.Experimental;

public class PlayerHealth : MonoBehaviour
{
    public int health = 4;
    [SerializeField] public TMP_Text HealthText;
    List<GameObject> healthList = new List<GameObject>();


    private void Start()
    {
        
        for( int i = 1; i <= health; i++ )
        {
            GameObject temp = GameObject.Find("Health" + i);
            temp.SetActive(true);
            healthList.Add(temp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collistion = collision.gameObject;
        if (collistion.CompareTag("attack"))
        {
            health -= 1;
            healthList[health].SetActive(false);
        }
    }
  
    private void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }
        if (health > 0)
        {
            for(int i = 0; i <= health - 1; i++)
            {
                healthList[i].SetActive(true);
            }
        }
    
        
    }

}
