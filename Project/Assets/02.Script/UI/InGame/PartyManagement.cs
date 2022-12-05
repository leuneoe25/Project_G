using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManagement : MonoBehaviour
{
    [SerializeField] private Image[] NowParty;
    [SerializeField] private Sprite[] colleagues;
    [SerializeField] private Sprite nullImage;
    [SerializeField] private Text partyNumber;
    List<Colleague> list;
    private int index;
    public int Index
    {
        get { return index; }
    }
    private void Start()
    {
        index = 0;
    }
    public void SetParty()
    {
        partyNumber.text = "ÆÄÆ¼ " + (index + 1);
        list = ColleagueSystem.Instance.GetDeck(index);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null)
                NowParty[i].sprite = colleagues[(int)list[i].club];
            else
                NowParty[i].sprite = nullImage;
        }
    }
    public void BeforeParty()
    {
        index = (index + 4) % 5;
        SetParty();
    }
    public void AfterParty()
    {
        index = (index + 1) % 5;
        SetParty();
    }
}
