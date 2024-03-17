using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject cam;
    public float transitionDuration = 2f;
    void Start()
    {
        cam = GetComponentInChildren<Camera>().gameObject;
        StartCoroutine(ReturnToPlayer());
        
    }
 public IEnumerator ReturnToPlayer()
    {
        yield return new WaitForSeconds(10.2f);
        cam.transform.position = transform.position;
    }
}
