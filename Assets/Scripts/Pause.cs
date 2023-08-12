using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause: MonoBehaviour
{

    public GameObject pause;
    bool paused = false;


    void Start()
    {
        pause.SetActive(false);
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false) 
        {

            pause.SetActive(true);
            Time.timeScale = 0;
            paused = true;

           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {

            pause.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && paused == true)
        {

            Application.Quit();
        }
    }
}