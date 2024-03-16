using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    public static void GameOver()
    {
        SceneManager.LoadScene("CityScene");
        UIManager.lives = 3;
    }
}
