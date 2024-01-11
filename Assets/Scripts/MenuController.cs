using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public static string Lvlname;

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public string ChangeLvl(string _sceneName)
    {
        SceneManager.LoadScene("niveau " + _sceneName.ToString());
        string lvlNumber = _sceneName;
        return lvlNumber;
    }

    public string NextLvl(string lvlNumber)
    {
        string nextlvl = (int.Parse(lvlNumber) + 1).ToString();
        SceneManager.LoadScene("niveau " + nextlvl);
        lvlNumber = nextlvl;
        return lvlNumber;

    }

    public void RetryLvl(string lvlNumber)
    {
        SceneManager.LoadScene("niveau " + lvlNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }
    

    public void Main(string _sceneName)
    {
        
        switch (_sceneName)
        {
            case "1":
            case "2":
            case "3":
                Lvlname = ChangeLvl(_sceneName);
                Debug.Log(Lvlname);
                break;
            case "retry":
                RetryLvl(Lvlname);
                Debug.Log(Lvlname);
                break;
            case "nextlvl":
                Lvlname = NextLvl(Lvlname);
                Debug.Log(Lvlname);
                break;
            default:
                ChangeScene(_sceneName);
                Debug.Log(Lvlname);
                break;
        }
    }
}
