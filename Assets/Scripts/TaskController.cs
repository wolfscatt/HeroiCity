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

    [Serializable]
    public struct Task
    {
        public int taskId;
        public String taskName;
        public bool isCompleted;
        public Sprite icon;
    }
    [SerializeField] private Task[] tasks;
    void Start()
    {
        var length = tasks.Length;
        for (int i = 0; i < length; i++)
        {
            CreateTaskPanel(tasks[i].taskName);
        }
    }
    private void Update()
    {

    }

    private void CreateTaskPanel(String taskName)
    {
        var taskPanel1 = Instantiate(taskPanel, transform);
        taskText = taskPanel1.transform.GetComponentInChildren<TextMeshProUGUI>();
        taskText.text = taskName;
        taskPanels.Add(taskPanel1);
    }

    public void CompleteTask()
    {
        var firstTask = taskPanels[0].gameObject.GetComponentsInChildren<Image>()[1];
        var secondTask = taskPanels[1].gameObject.GetComponentsInChildren<Image>()[1];
        var thirdTask = taskPanels[2].gameObject.GetComponentsInChildren<Image>()[1];
        firstTask.sprite = completeImage;
        if(firstTask.sprite == completeImage)
        {
            secondTask.sprite = completeImage;
        }
        else if(secondTask.sprite == completeImage)
        {
            thirdTask.sprite = completeImage;
        }
        else if(thirdTask.sprite == completeImage)
        {
            Debug.Log("Tebrikler! Oyunu bitirdiniz.");
        }
       
    }


}

