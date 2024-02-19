using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSence : MonoBehaviour
{
    // Start is called before the first frame update
    //all of the script was writen but Scott
    // script used to change snece 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void swtichSence (string sencename) 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sencename);
    }  
}
