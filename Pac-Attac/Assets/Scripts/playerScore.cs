using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    public void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

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

        highScoreEntryList = new List<HighScoreEntry>()
        {

        }
        //sort entry list by score
        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = 0; j < highScoreEntryList.Count; j++)
            {
                if (highScoreEntryList[j] > highScoreEntryList[i])
                {//swap
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
        }
        string json = JsonUtility = ToJson(highScoreEntryList);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        PlayerPrefs.GetString("highscoreTable");
        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List < Transform > transformList);
        }
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List <Transform> transformList)
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
            
            entryTransform.Find("postext").GetComponant<Text>().text = "";

            int score = highScoreEntry.score;
            entryTransform.Find("scoretext").GetComponant<Text>().text = "";

            string name = highScoreEntry.name;
            entryTransform.Find("nametext").GetComponant<Text>().text = "";

            transformList.Add(entryTransform);
        }
    }
        [System.Serializable] 
    private class HighscoreEntry()
    {
        public int score;
        public int name;
    }
}
