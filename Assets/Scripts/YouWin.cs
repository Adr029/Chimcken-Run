using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    [SerializeField] PlayerMovement gamecomplete;
    [SerializeField] Text Winner;

    private void Start()

    {
        Winner.text = "";

    }

    private void Update()
    {
        if (gamecomplete.complete == true)
        {
            Winner.text = "YOU WIN!";
        }
        else
        {

            Winner.text = "";
        }
    }
}
