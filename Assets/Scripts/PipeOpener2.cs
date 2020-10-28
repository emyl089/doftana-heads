using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOpener2 : MonoBehaviour
{
    public GameObject pipe;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator myScript = pipe.GetComponent<Animator>();
            myScript.enabled = true;
            Debug.Log("Enter");
        }
    }
}
