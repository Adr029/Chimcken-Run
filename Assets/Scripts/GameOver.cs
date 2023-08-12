using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlayerMovement health;
    [SerializeField] Text GameOverText;

    private void Start()

    {
        GameOverText.text = "";

    }

    private void Update()
    {
        if (health.playerhealth == 0f)
        {
            GameOverText.text = "GAME OVER";
        }
        else {

            GameOverText.text = "";
        }
    }
}
