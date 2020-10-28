using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject levelOverCanvas;
    public GameObject scoreCanvas;

    public float velocity = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            FindObjectOfType<AudioManager>().Play("Flap");
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "pipe")
        {
            gameManager.GameOver();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            FindObjectOfType<AudioManager>().Play("PipeHit");
        }

        if (target.gameObject.tag == "ground")
        {
            gameManager.GameOver();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            FindObjectOfType<AudioManager>().Play("GroundHit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "levelend")
        {
            LevelOver();
        }
    }

    private void LevelOver()
    {
        levelOverCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        Time.timeScale = 0;
    }
}
