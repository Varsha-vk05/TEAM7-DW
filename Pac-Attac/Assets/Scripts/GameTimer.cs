using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float timerDuration = 120.0f;  
    private float timer;
    private bool timerActive = true; 

    void Start()
    {
        timer = timerDuration;
        UpdateTimerText();
    }

    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;  

            if (timer <= 0)
            {
                timer = 0;  
                timerActive = false;  
                EndGame();
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
       
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        
        timerText.text = string.Format("{0}:{1:00}s", minutes, seconds);
    }

    void EndGame()
    {
       
        SceneManager.LoadScene("GameEnd");  
    }
}
