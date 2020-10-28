using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject levels;
    public GameObject bird;
    public GameObject highscore;

    private void Start()
    {
        levels.SetActive(false);
        menu.SetActive(true);
        highscore.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void Levels()
    {
        levels.SetActive(true);
        menu.SetActive(false);
        bird.SetActive(false);
        highscore.SetActive(false);
    }

    public void Back()
    {
        levels.SetActive(false);
        menu.SetActive(true);
        bird.SetActive(true);
        highscore.SetActive(false);
    }
    public void Highscore()
    {
        levels.SetActive(false);
        menu.SetActive(false);
        bird.SetActive(false);
        highscore.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
    }

    public void Level4()
    {
        SceneManager.LoadScene(5);
    }

    public void Level5()
    {
        SceneManager.LoadScene(6);
    }

    public void Level6()
    {
        SceneManager.LoadScene(7);
    }

    public void Level7()
    {
        SceneManager.LoadScene(8);
    }

    public void Level8()
    {
        SceneManager.LoadScene(9);
    }

    public void Level9()
    {
        SceneManager.LoadScene(10);
    }
}
