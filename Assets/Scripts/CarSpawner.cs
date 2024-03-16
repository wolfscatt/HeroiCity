using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject[] cars;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar(time));
    }

    public IEnumerator SpawnCar(float time)
    {

        System.Random randomNumber = new System.Random();
        
        while (true)
        {
            int car1Index = randomNumber.Next(0, cars.Length);
            int car2Index = randomNumber.Next(0, cars.Length);

            GameObject car = Instantiate(cars[car1Index], new Vector3(160, 0, -239), Quaternion.Euler(0, -90, 0));
            GameObject car2 = Instantiate(cars[car2Index], new Vector3(95, 0, -246), Quaternion.Euler(0, 90, 0));

            car.AddComponent<MoveLeft>();
            car2.AddComponent<MoveRight>();

            yield return new WaitForSeconds(time);

        }
    }
}
