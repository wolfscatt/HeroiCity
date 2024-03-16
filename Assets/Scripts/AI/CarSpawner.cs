using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;
    void Start()
    {
        Instantiate(SelectCarPrefab(), transform);
    }

    private GameObject SelectCarPrefab()
    {
        var randomIndex = UnityEngine.Random.Range(0, carPrefabs.Length);
        return carPrefabs[randomIndex];
    }
}
