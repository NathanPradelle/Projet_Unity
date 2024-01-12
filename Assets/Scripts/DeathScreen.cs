using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public MenuController MenuController;
    public Text highscoreText;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Your Highscore: " + PlayerPrefs.GetInt("highscore" + MenuController.Lvlname).ToString();
        scoreText.text = "Your score : " + PlayerPrefs.GetInt("score").ToString();
    }
}
