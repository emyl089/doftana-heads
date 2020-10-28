using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float speed;
    public float up;
    public float down;
    int updown = 1;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y < down)
           updown = 1;
        else if (transform.position.y > up)
           updown = 2;

        switch (updown)
        {
            case 1:
                transform.position += Vector3.up * speed * Time.deltaTime;
                break;

            case 2:
                transform.position += Vector3.up * (-speed) * Time.deltaTime;
                break;
        }
    }
}
