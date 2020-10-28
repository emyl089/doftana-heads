using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject cloud;
    public float height;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newcloud = Instantiate(cloud);
        newcloud.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newcloud = Instantiate(cloud);
            newcloud.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newcloud, lifeTime);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
