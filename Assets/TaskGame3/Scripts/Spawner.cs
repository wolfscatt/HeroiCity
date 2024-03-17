using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Fruit[] fruitPrefabs;
    public GameObject bombPrefab;
    public float bombChance = 0.05f;

    [SerializeField] private int amount = 10;
    public float spawnRate = 1f;
    private static Spawner instance;
    public static Spawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Spawner>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private void CreateRandomFruit()
    {
        var randomRange = Random.Range(0, fruitPrefabs.Length);
        Instantiate(fruitPrefabs[randomRange], transform.position, Quaternion.identity);
    }
    public void Spawn()
    {
        CreateRandomFruit();
        if (Random.value < bombChance){
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }

    }
    private IEnumerator StartSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Spawn();
        }
    }
}
