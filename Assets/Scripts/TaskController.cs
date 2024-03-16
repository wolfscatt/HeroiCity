using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    private List<GameObject> taskPanels = new List<GameObject>();
    private TextMeshProUGUI taskText;
    [SerializeField] private GameObject taskPanel;
    [SerializeField] private Sprite completeImage;
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Task[] tasks;
    void Awake()
    {
        CreateTaskPanel();
        RestoreTaskStatusFromPrefs();
        
    }
    private void Update()
    {
        UpdateTaskVisuals();
    }

    private void CheckTaskCompletion()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].isCompleted)
            {
                // Eğer task tamamlanmamışsa, kontrol et
                // Örneğin, bu taskı oyun içi olaylar veya diğer koşullarla kontrol edebilirsiniz
                // Burada herhangi bir örnek senaryo gösterilmemiştir.
            }
        }
    }

    private void CreateTaskPanel()
    {
        foreach (var task in tasks)
        {
            var taskPanel1 = Instantiate(taskPanel, transform);
            taskText = taskPanel1.transform.GetComponentInChildren<TextMeshProUGUI>();
            taskText.text = task.taskName;
            taskPanels.Add(taskPanel1);
            //PlayerPrefs.SetInt("taskCompleted" + task.taskId , 0);
        }

    }

    public void CompleteTask(int taskIndex)
    {
        tasks[taskIndex].isCompleted = true;
        UpdateTaskVisuals();
    }
   public void RestoreTaskStatusFromPrefs()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i].isCompleted = PlayerPrefs.GetInt("taskCompleted" + (i+1)) == 1;
        }
        UpdateTaskVisuals();
    }

    private void UpdateTaskVisuals()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            var taskImage = taskPanels[i].GetComponentsInChildren<Image>()[1];
            taskImage.sprite = tasks[i].isCompleted ? completeImage : defaultImage;
        }
    }


    [Serializable]
    public struct Task
    {
        public int taskId;
        public String taskName;
        public bool isCompleted;
        public Sprite icon;
    }

}

