using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    public GameObject winPanel;
    public GameObject gameOverPanel;
    private static GameManager3 instance;
    public static GameManager3 Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager3>();
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        NewGame();
    }
    public void WinGame()
    {
        Time.timeScale = 0;
        if(score >= 500)
        {
            winPanel.SetActive(true);
        }
    }

    public void NewGame()
    {
        
        score = 0;
        scoreText.text = $"Score: {score}";
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }
    public void Explode()
    {
        Time.timeScale = 0;
        // Show Game Over Panel
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        NewGame();
    }

    public void Quit()
    {
        SceneManager.LoadScene("CityScene");
    }
}
