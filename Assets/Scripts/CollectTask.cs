using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //taskController.CompleteTask();
        }
    }
}
