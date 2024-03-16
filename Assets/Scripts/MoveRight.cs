using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 8.5f);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

}
