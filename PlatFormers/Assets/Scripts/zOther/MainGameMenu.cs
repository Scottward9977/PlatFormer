using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class MainGameMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool pause = false;
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape))
        {
            pause = !pause;
        }
        if(pause)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true); 
        }
        else if(!pause)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(false);  
        }

    }
}
