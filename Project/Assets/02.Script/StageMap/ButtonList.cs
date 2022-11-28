using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonList : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public void Add(Button button)
    {
        buttons.Add(button);
    }
    public void PrintListElements()
    {
        for(int i = 0; i < buttons.Count; ++i)
        {
            Debug.Log(buttons[i].ToString());
        }
    }

    public Button GetButtonInfo(int num)
    {
        return buttons[num];
    }


}
