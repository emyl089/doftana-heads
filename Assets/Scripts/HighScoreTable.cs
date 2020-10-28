using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Un pic stricat
public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

    private void CreateHighscoreEntry(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templeHeight = 80f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templeHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + " TH";
                break;
            case 1:
                rankString = "1 ST";
                break;
            case 2:
                rankString = "2 ND";
                break;
            case 3:
                rankString = "3 RD";
                break;
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        //Set background visible to odds
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        //Highlight first
        if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }

        //Set trophy
        switch(rank)
        {
            default:
                entryTransform.Find("trophy").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(255, 251, 0, 100);
                break;
            case 2:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                break;
            case 3:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(203, 114, 33, 100);
                break;
        }

        transformList.Add(entryTransform);
    }

    private void Awake()
    {
        AddHighscoreEntry(10, "YOU");
        Debug.Log(PlayerPrefs.GetString("HighsScoreTable"));

        entryContainer = transform.Find("entryContainer");
        entryTemplate = entryContainer.Find("entryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Sort by score
        for(int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntry(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    public void AddHighscoreEntry(int score, string name)
    {
        //Create Highscore Entry
        HighscoreEntry highscoreEntry = new HighscoreEntry
        {
            score = score,
            name = name
        };

        //Load saved Highscore
        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Add new entry to Highscore
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated Highscore
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
    }
}
