using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    public static UIHome Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");      
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
