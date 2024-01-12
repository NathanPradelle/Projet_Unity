using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    
    public Text highestTimeText;

    public Text TimeText;
    public MenuController MenuController;
    // Start is called before the first frame update
    void Start()
    {
        TimeText.text = "Your Time : " + PlayerPrefs.GetFloat("Time").ToString("F2");
        highestTimeText.text = "Your Best Time : " + PlayerPrefs.GetFloat("Timer" + MenuController.Lvlname).ToString("F2");
    }
    
}
