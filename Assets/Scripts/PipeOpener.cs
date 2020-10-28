using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOpener : MonoBehaviour
{
    public GameObject pipe;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OpenPipe myScript = pipe.GetComponent<OpenPipe>();
            myScript.enabled = true;
            Debug.Log("Enter");
        }
    }
}
