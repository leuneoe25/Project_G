using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPause;

    void Start()
    {
        isPause = false;
    }

    public void ClickPause()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
        }
    }
}
