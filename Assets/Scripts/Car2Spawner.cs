using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Spawner : MonoBehaviour
{
    public GameObject[] cars;

    public bool carDeleted = false;

    public float time = 2.7f;

    void Start()
    {
        StartCoroutine(SpawnCar(time));
    }

    public IEnumerator SpawnCar(float time)
    {
        System.Random randomNumber = new System.Random();

        while (!carDeleted)
        {
            int car1Index = randomNumber.Next(0, cars.Length);
            int car2Index = randomNumber.Next(0, cars.Length);

            GameObject car1 = Instantiate(cars[car1Index], new Vector3(90, 0, -246), Quaternion.Euler(0, 90, 0));
            GameObject car2 = Instantiate(cars[car2Index], new Vector3(160, 0, -239), Quaternion.Euler(0, -90, 0));

            car1.AddComponent<MoveRight>();
            car2.AddComponent<MoveLeft>();

            yield return new WaitForSeconds(time);
        }

    }
}
