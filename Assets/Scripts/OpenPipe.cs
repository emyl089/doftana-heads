using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPipe : MonoBehaviour
{
    public float speed;

    public GameObject topPipe;
    public GameObject bottomPipe;


    private void Update()
    {
        topPipe.transform.position += Vector3.up * speed * Time.deltaTime;
        bottomPipe.transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
