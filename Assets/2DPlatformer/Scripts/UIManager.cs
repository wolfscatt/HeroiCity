using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int lives = 3;
    public void PlayAgain()
    {
        SceneManager.LoadScene("Task1Platform");
    }

    public void Continue()
    {   
        PlayerPrefs.SetString("scene", "Task1Platform");
        SceneManager.LoadScene("CityScene");
    }

}
