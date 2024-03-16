using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    
}
