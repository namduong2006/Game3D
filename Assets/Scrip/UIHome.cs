using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    public static UIHome Instance;
    [SerializeField] GameObject loading;
    [SerializeField] Image loadingbarfill;
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0.1f;
    }
    public void LoadingScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));       
    }
    IEnumerator LoadSceneAsync(string namescene)
    {
        AsyncOperation opration = SceneManager.LoadSceneAsync(namescene);
        loading.SetActive(true);
        while (!opration.isDone)
        {           
            float progressvalue = Mathf.Clamp01(opration.progress/0.9f);
            loadingbarfill.fillAmount = progressvalue;
            yield return null;
        }       
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
