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

    public void ExitGame()
    {
        Application.Quit();
    }
}
