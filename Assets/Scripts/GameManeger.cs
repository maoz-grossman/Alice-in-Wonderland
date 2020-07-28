using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update


    public Text scoreText;
    private int score; 
    void Start()
    {
        scoreText.text = "SCORE: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "SCORE: " + score;

    }
}
