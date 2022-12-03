using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColleagueList : MonoBehaviour
{
    [Header("Type Button")]
    [SerializeField] private Button AllButton;
    [SerializeField] private Button AttackButton;
    [SerializeField] private Button DebuffButton;
    [SerializeField] private Button SupportButton;
    [Header("ListObject")]
    [SerializeField] private List<GameObject> colleagueList;

    private List<Colleague> colleagues;
    void Start()
    {
        colleagues = ColleagueSystem.Instance.Getcolleagues();
        AllButton.onClick.AddListener(AllButtonFunc);
    }

    void AllButtonFunc()
    {
        for (int i = colleagues.Count; i < colleagueList.Count; i++)
        {
            if(i> colleagues.Count)
            {
                colleagueList[i].SetActive(false);
                continue;
            }

        }
    }
}
