using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    public GameObject diamondPrefab; // Diamond GameObject'in prefab'ini ekleyin

    public bool diamondDeleted = false;

    public float time = 2.7f;

    void Start()
    {
        StartCoroutine(SpawnDiamond(time));
    }

    public IEnumerator SpawnDiamond(float time)
    {
        while (!diamondDeleted)
        {
            float randomNumber = Random.Range(-10, 10);
           
            Instantiate(diamondPrefab, new Vector2(randomNumber, 15), Quaternion.identity); // Diamond prefab'ini Instantiate edin

            yield return new WaitForSeconds(time);
        }
    }

}