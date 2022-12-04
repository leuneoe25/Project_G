using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendGetTime : MonoBehaviour
{
    [SerializeField] Button button;
    public int time;
    private int tempTime;
    private float onesec = 1;
    int min;
    int h;
    public bool PushButton;

    void ButtonPush()
    {
        PushButton = true;
        tempTime = time;
        SetText();
    }


    void SetTextToDefalut()
    {
        Text text = button.transform.GetChild(1).GetComponent<Text>();
        text.text = "모집";
    }

    void SetTime()
    {
        if (time >= 60)
        {
            min = time / 60;
            time %= 60; 
            if (min >= 60)
            {
                h = min / 60;
                min %= 60;
            }
        }
    }

    void SetText()
    {
        Text text = button.transform.GetChild(1).GetComponent<Text>();


        if(h > 0)
        {
            text.text = h.ToString() + "시간 " + min.ToString() + "분 " + time.ToString() + "초";
        }
        else if(min > 0)
        {
            text.text = min.ToString() + "분 " + time.ToString() + "초";
        }
        else if (time >0)
        {
            text.text = time.ToString() + "초";
        }

    }

    void Start()
    {
        button.onClick.AddListener(() => ButtonPush());
        SetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (PushButton)
        {
            onesec -= Time.deltaTime;
            if (onesec <= 0)
            {
                Debug.Log(h + "시간 " + min + "분 " + time + "초");
                time -= 1;
                if (time <= 0)
                {
                    if (min > 0)
                    {
                        time += 60;
                        min--;
                    }
                    else
                    {
                        if (h > 0)
                        {
                            min += 60;
                            h--;
                        }
                    }
                }
                SetText();
                if (min <= 0 && h <= 0 && time <= 0)
                {
                    //func of recruitment;
                    PushButton = false;
                    SetTextToDefalut();
                    time = tempTime;

                }
                onesec = 1;
            }
        }
    }
}
