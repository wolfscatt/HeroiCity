using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectTask : MonoBehaviour
{
    private TaskController taskController;

    private void Start() 
    {
        taskController = FindObjectOfType<TaskController>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Görev tetiklenince yeni bir sahnede basit bir oyun açılacak. Ve onun sonucuna göre başarılı ya da başarısız olacak.
            //taskController.CompleteTask();
            if(gameObject.CompareTag("Task1"))
            {
                PlayerPrefs.SetInt("taskCompleted1", 1);
                taskController.CompleteTask(0);
                SceneManager.LoadScene("Task1Platform");
            }
            else if(gameObject.CompareTag("Task2"))
            {
                PlayerPrefs.SetInt("taskCompleted2", 1);
                taskController.CompleteTask(1);
                SceneManager.LoadScene("Task2Platform");
            }
            else if(gameObject.CompareTag("Task3"))
            {
                PlayerPrefs.SetInt("taskCompleted3", 1);
                taskController.CompleteTask(2);
                SceneManager.LoadScene("Task3Platform");
            }
            
        }
    }
}
