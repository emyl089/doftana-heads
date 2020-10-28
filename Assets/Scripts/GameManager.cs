using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject scoreCanvas;
    public GameObject pauseCanvas;
    public GameObject tapToPlay;
    public GameObject tapToPlayButton;
    public GameObject getReady;
    public GameObject pauseButton;

    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void Play()
    {
        Time.timeScale = 1;
        tapToPlay.SetActive(false);
        tapToPlayButton.SetActive(false);
        getReady.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
