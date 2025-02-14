using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndButton : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");  
    }

    public void QuitGame()
    {
        Application.Quit();  

       
        //UnityEditor.EditorApplication.isPlaying = false;

    }
}
