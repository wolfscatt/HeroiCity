using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Fruit : MoveUpObjects
{
    protected Rigidbody rb;
    protected Collider objectCollider;
    [Header("Slice")]
    public GameObject whole;
    public GameObject sliced;
    private ParticleSystem fruitEffect;
    public int point = 10;

    public void Start()
    {
        fruitEffect = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
        ForceObject(rb);
        transform.position = GetRandomPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Slice blade = other.GetComponent<Slice>();
            SliceFruit(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }

    private void SliceFruit(Vector3 direction, Vector3 position, float force)
    {
        // Increase Score
        GameManager3.Instance.IncreaseScore(point);
       
        objectCollider.enabled = false;

        fruitEffect.Play();

        whole.SetActive(false);
        sliced.SetActive(true);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (var slice in slices)
        {
            slice.velocity = rb.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
    
}

public abstract class MoveUpObjects : MonoBehaviour
{

    public float minForce = 19f;
    public float maxForce = 24f;
    public float angleRange = 15f;
    public float xRange = 5f;
    public float zRange = 1f;
    public float yPosition = -10f;

    public void ForceObject(Rigidbody rb)
    {
        var force = Random.Range(minForce, maxForce);
        rb.AddForce(force * transform.up, ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }
    private float RandomTorque()
    {
        return Random.Range(-angleRange, angleRange);
    }
    protected Vector3 GetRandomPosition()
    {
        var randomPos = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
        return randomPos;
    }
}
