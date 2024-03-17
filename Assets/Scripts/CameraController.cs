using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject cam;
    public float transitionDuration = 10.2f;
    void Start()
    {
        cam = GetComponentInChildren<Camera>().gameObject;
        StartCoroutine(ReturnToPlayer());
        
    }
 public IEnumerator ReturnToPlayer()
    {
        yield return new WaitForSeconds(transitionDuration);
        cam.transform.position = transform.position;
    }
}
