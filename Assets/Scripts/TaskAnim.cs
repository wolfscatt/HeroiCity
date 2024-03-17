using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAnim : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float amplitude = 1f;
    public float frequency = 1f;
    
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = initialPosition + new Vector3(0f, yOffset, 0f);
    }
}
