using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    [SerializeField] PlayerMovement playerscore;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerscore.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerscore.score.ToString();
    }
}
