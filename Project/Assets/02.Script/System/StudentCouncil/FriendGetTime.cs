using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendGetTime : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Button X;
    [SerializeField] GameObject Object;
    [SerializeField] Text[] text;
    [SerializeField] string[] TextText;
    public int cost;

    private void Start()
    {
        button.onClick.AddListener(() => PushButton());
    }

    private void TextSet()
    {
        text[0].text = TextText[0] + GoodsSystem.Instance.GSetCouncilLv().ToString() + "µî±Þ";
        text[1].text = TextText[1] + ColleagueSystem.Instance.Getcolleagues().Count + " / 18";
        text[2].text = TextText[2] + cost.ToString();
    }

    public void GetPlayer()
    {
        Object.SetActive(false);
    }

    public void PushButton()
    {
        if(!Object.activeSelf)
        {
            Object.SetActive(true);
            TextSet();
            X.onClick.AddListener(() => PushButton());
        }
        else
        {
            Object.SetActive(false);
        }
    }
}
