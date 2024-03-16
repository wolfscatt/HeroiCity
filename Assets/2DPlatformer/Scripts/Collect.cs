using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    public List<string> keys = new List<string>();
    private AudioSource audioSource;
    public static Collect Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedKey"))
        {
            keys.Add("RedKey");
            Destroy(collision.gameObject);
            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("YellowKey"))
        {
            keys.Add("YellowKey");
            Destroy(collision.gameObject);
            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("BlueKey"))
        {
            keys.Add("BlueKey");
            Destroy(collision.gameObject);
            audioSource.Play();
        }
    }

}
