using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("TestAnimationScene");
    }
    public void LoadStore()
    {
        SceneManager.LoadScene("Store");
    }
    public void LoadStudentCouncil()
    {
        SceneManager.LoadScene("StudentCouncil");
    }
    public void LoadColleague()
    {
        SceneManager.LoadScene("Colleague");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }


    public void OpenStage()
    {
        ClearChack.Instance.OpenStage();
    }
}
