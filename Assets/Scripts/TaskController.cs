using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    private List<GameObject> taskPanels = new List<GameObject>();
    private bool isCompleted = false;
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
            CreateTaskPanel(tasks[i].taskName, tasks[i].isCompleted);
        }
    }
    private void Update()
    {

    }

    private void CreateTaskPanel(String taskName, bool isCompleted)
    {
        var taskPanel1 = Instantiate(taskPanel, transform);
        taskText = taskPanel1.transform.GetComponentInChildren<TextMeshProUGUI>();
        taskText.text = taskName;
        taskPanels.Add(taskPanel1);
    }


}

