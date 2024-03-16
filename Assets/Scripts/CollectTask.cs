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
            taskController.CompleteTask();
            SceneManager.LoadScene("Task1Platform");
        }
    }
}
