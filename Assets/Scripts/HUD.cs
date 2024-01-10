using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public Player Player;
    public MenuController MenuController;
    private float highscore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "HIGHSCORES: " + highscore.ToString();
    }

    void Update()
    {
        scoreText.text = Player.pourcent.ToString();
    }

    public void Highest() {
        if (highscore < Player.pourcent)
        {
            highscore = Player.pourcent;
            highscoreText.text = "HIGHSCORES for " + MenuController.Lvlname + " : " + highscore.ToString();
        }
    }
}
