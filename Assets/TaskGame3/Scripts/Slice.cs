using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    private bool slicing;
    private Collider bladeCol;
    private Camera cam;
    private TrailRenderer bladeTrail;
    public Vector3 direction { get; private set;}
    public float minSliceVelocity = 0.1f;
    public float sliceForce = 5f;
    private void Awake()
    {
        bladeCol = GetComponent<Collider>();
        bladeTrail = GetComponent<TrailRenderer>();
        // Farenin dünya koordinatlarındaki pozisyonunu almak için kamera kullanılır.
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        var newPositon = cam.ScreenToWorldPoint(Input.mousePosition);
        newPositon.z = 0;
        transform.position = newPositon;

        slicing = true;
        bladeCol.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void StopSlicing()
    {
        slicing = false;
        bladeCol.enabled = false;
        bladeTrail.enabled = false;
    }
    private void ContinueSlicing()
    {
        // Fare pozisyonunu al
        var newPositon = cam.ScreenToWorldPoint(Input.mousePosition);
        newPositon.z = 0;
        // Farenin pozisyonu ile collider'ın pozisyonu arasındaki farkı bize yönü verir.
        direction = newPositon - transform.position;
        // Burada ise gerçekten slice işlemi yapılıp yapılmayacağını kontrol ediyoruz.
        var velocity = direction.magnitude / Time.deltaTime;
        bladeCol.enabled = velocity > minSliceVelocity;
        // Ve son olarak collider'ın pozisyonunu güncelliyoruz.
        transform.position = newPositon;
    }
}
