using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private List<string> keys = new List<string>();
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        keys = Collect.Instance.keys;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player2D") && keys.Contains("RedKey"))
        {
            keys.ForEach(key => Debug.Log(key));
            Debug.Log(keys.Count);
            boxCollider2D.isTrigger = true;
        }
        else if(collision.gameObject.CompareTag("Player2D") && keys.Contains("YellowKey"))
        {
            boxCollider2D.isTrigger = true;
        }
        else if (collision.gameObject.CompareTag("Player2D") && keys.Contains("BlueKey"))
        {
            boxCollider2D.isTrigger = true;
        }
    }
}
