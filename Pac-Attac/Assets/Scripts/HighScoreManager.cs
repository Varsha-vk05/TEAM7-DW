using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("HighscoreentryContainer");
        entryTemplate = transform.Find("HIghscoreEntryTemplate");
    }
}
