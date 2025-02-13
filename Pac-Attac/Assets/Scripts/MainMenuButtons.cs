using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject tutorialCanvas; 

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

  
    public void ToggleTutorial()
    {
        if (tutorialCanvas != null)
        {
            
            tutorialCanvas.SetActive(!tutorialCanvas.activeSelf);
        }

    }

    public void CloseTutorial()
    {
        if (tutorialCanvas != null)
        {
            tutorialCanvas.SetActive(false); 
        }
    }
}
