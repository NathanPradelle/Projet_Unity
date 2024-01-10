using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Player Player;
    public MenuController MenuController;
    public Text highscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "HIGHSCORES: " + Player.highscore[int.Parse(MenuController.Lvlname) - 1].ToString();
    }
}
