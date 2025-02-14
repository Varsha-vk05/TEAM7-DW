using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("HighscoreentryContainer");
        entryTemplate = transform.Find("HIghscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //  highScoreEntryList = new List<HighScoreEntry>()
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //sort entry list by score
        for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
        {
            for (int j = 0; j < highscores.highScoreEntryList.Count; j++)
            {
                if (highscores.highScoreEntryList[j] > highscores.highScoreEntryList[i].score)
                {//swap
                    HighScoreEntry tmp = highscores.highScoreEntryList[i];
                    highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = tmp;
                }
            }
        }
        Highscores highscores = new Highscores (highscoreEntryList = highScoreEntryList );

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List < Transform > transformList);
        }
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponant<entryRectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = i + 1;
        string rankString;
        switch (rank);
        {
            default: 
                rankString = rank + "TH"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
            }
            entryTransform.Find("postext").GetComponant<Text>().text = rankString;

            int score = highScoreEntry.score;
            entryTransform.Find("scoretext").GetComponant<Text>().text = score.ToString();

            string name = highScoreEntry.name;
            entryTransform.Find("nametext").GetComponant<Text>().text = name;

            transformList.Add(entryTransform);

        }
    }
    private class AddHighscoreEntry(int score, string name)//creates high score entry
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry ( score = score, name = name );

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highScoreEntryList.Add(highscoreEntry);

        string json = JsonUtility = ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        PlayerPrefs.GetString("highscoreTable");
    }
    private class Highscores()
    {
        public List<HighscoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry()
    {
        public int score;
        public string name;
    }
}
