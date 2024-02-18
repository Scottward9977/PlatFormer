using JetBrains.Annotations;
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
    public GameObject pauseScreen;
    public int killCount;
    public GameObject endScreen;
    private bool pause = false;
    [SerializeField] public Animator ainimation;
    

    private void Start()
    {

        pauseScreen.SetActive(false);
        endScreen.SetActive(false);

        for (int i = 1; i <= health; i++)
        {
            GameObject temp = GameObject.Find("Health" + i);
            temp.SetActive(true);
            healthList.Add(temp);
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            endScreen.SetActive(true);
            ainimation.SetInteger("anima", 1);
            HealthText.text = "You killed " + killCount + " Enemys";
            Invoke("SetTime", 1);

        }
        if (health > 0)
        {
            for (int i = 0; i <= health - 1; i++)
            {
                healthList[i].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else if (!pause && health > 0)
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collistion = collision.gameObject;
        if (collistion.CompareTag("attack"))
        {
            if(health > 0)
            {
                health -= 1;
                healthList[health].SetActive(false);
            }
           
        }
    }
    void SetTime()
    {
        Time.timeScale = 0;
    }

}