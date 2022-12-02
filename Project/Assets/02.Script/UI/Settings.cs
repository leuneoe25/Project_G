using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void OpenSetting()
    {
        gameObject.SetActive(true);
    }
    public void CloseSetting()
    {
        gameObject.SetActive(false);
    }

    public void ResetData()
    {
        //DB 리셋하기
    }
}
