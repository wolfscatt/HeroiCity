using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CarAI : MonoBehaviour
{
    private GameObject wayPoint;
    private Transform[] wayPoints;
    private int currentWayPointIndex = 0;
    private NavMeshAgent agent;

    private void Start() {
        wayPoint = GameObject.Find("WayPoints");
        wayPoints = wayPoint.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        SetNextWaypoint();
    }

    void SetNextWaypoint()
    {
        if (currentWayPointIndex < wayPoints.Length)
        {
            agent.SetDestination(wayPoints[currentWayPointIndex].transform.position);
        }
        else
        {
            Debug.Log("Finish!");
            // Yolun sonuna ulaşıldığında yapılacak işlemler buraya eklenebilir.
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWayPointIndex++;
            SetNextWaypoint();
        }
    }
}
