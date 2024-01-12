using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LvlSelection : MonoBehaviour
{

    public Text Highest1;
    
    public Text Highest2;
    
    public Text Highest3;
    // Start is called before the first frame update
    void Start()
    {
        Highest1.text = PlayerPrefs.GetInt("highscore1").ToString() + '%';
        Highest2.text = PlayerPrefs.GetInt("highscore2").ToString() + '%';
        Highest3.text = PlayerPrefs.GetInt("highscore3").ToString() + '%';
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
