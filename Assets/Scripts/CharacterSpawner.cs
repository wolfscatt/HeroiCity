using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        Instantiate(characterPrefab, transform.position, Quaternion.identity);
    }
    
}
