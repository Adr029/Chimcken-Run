using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField] PlayerMovement health;
    [SerializeField] Text ReloadText;
    [SerializeField] PlayerMovement gamecomplete;

    private void Start()

    {
        ReloadText.text = "";

    }

    private void Update()
    {
        if (health.playerhealth == 0f)
        {
            ReloadText.text = "PRESS R TO RESTART";
        }
        else if (gamecomplete.complete == true) 
        {
            ReloadText.text = "PRESS R TO START A NEW GAME";

        }
        else
        {

            ReloadText.text = "";
        }
    }
}
