using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;

    private void Start() 
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Oyun zamanını durdur
        pausePanel.SetActive(true); // Duraklatma panelini aktif hale getir
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Oyun zamanını devam ettir
        pausePanel.SetActive(false); // Duraklatma panelini devre dışı bırak
    }
}
