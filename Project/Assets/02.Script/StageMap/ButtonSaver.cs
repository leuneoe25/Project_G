using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSaver : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] ButtonList buttonList;
    [SerializeField] ButtonAnimation buttonAnimation;


    private void Start()
    {
        buttonList = GetComponent<ButtonList>();    
        for(int i = 0; i < buttons.Length; ++i)
        {
            buttonList.Add(buttons[i]);
            int a = i;
            buttonList.buttons[i].onClick.AddListener(() => ButtonFunc(a));
        }

    }

    void ButtonFunc(int num)
    {
        buttonAnimation.UnlockNextStage(num);
    }

    
}
