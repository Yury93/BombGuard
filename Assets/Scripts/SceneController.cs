using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonBase<SceneController>
{
    [SerializeField] private string sceneName;
    public void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void FailScene()
    {
        SceneManager.LoadScene("Fail");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
