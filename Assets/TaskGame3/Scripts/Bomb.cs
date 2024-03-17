using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MoveUpObjects
{
    protected Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ForceObject(rb);
        transform.position = GetRandomPosition();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            GameManager3.Instance.Explode();
        }
    }
}
