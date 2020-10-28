using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI mText;
    public TextMeshProUGUI deadScore;
    public TextMeshProUGUI deadHighScore;

    public GameObject iron;
    public GameObject bronze;
    public GameObject gold;
    public GameObject platinum;

    private HighScoreTable highscoreTable;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        deadHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mText = GetComponent<TextMeshProUGUI>();
        mText.text = score.ToString();
        deadScore.text = score.ToString();

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            deadHighScore.text = score.ToString();
        }

        if (score >= 10 && score <= 19)
        {
            iron.SetActive(true);
        }
        else if (score >= 20 && score <= 29)
        {
            iron.SetActive(false);
            bronze.SetActive(true);
        }
        else if (score >=30 && score <= 49)
        {
            iron.SetActive(false);
            bronze.SetActive(false);
            gold.SetActive(true);
        }
        else if(score >=50)
        {
            iron.SetActive(false);
            bronze.SetActive(false);
            gold.SetActive(false);
            platinum.SetActive(true);
        }
        else
        {
            iron.SetActive(false);
            bronze.SetActive(false);
            gold.SetActive(false);
            platinum.SetActive(false);
        }
    }
}
