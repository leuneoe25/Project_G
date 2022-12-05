using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColleagueOrganization : MonoBehaviour
{
    [SerializeField] private Sprite[] image;
    [SerializeField] private EffectSystem effect;
    [SerializeField] private Text BackText;
    [SerializeField] private Text Guide;
    [SerializeField] private Button OnColleagueOrganization;
    [SerializeField] private Button OnColleagueList;
    [SerializeField] private GameObject ColleagueOrganizationObject;
    [SerializeField] private GameObject ColleagueListObject;

    [Header("Arrow")]
    [SerializeField] private Button LeftArrow;
    [SerializeField] private Button RightArrow;
    [SerializeField] private Text DeckNumber;
    [SerializeField] private Button ResetButton;
    private int DeckNum = 0;

    [Header("Deck")]
    [SerializeField] private Button[] DeckList;
    [SerializeField] private Button[] DeckInfo;
    [SerializeField] private Button[] DeckClear;
    [SerializeField] private Button Move;
    [SerializeField] private Button MoveCancel;
    [SerializeField] private GameObject MoveState;
    [SerializeField] private Button AllClear;

    [Header("Type Button")]
    [SerializeField] private Button AllButton;
    [SerializeField] private Button AttackButton;
    [SerializeField] private Button DebuffButton;
    [SerializeField] private Button SupportButton;
    [SerializeField] private List<Button> ColleagueListButton;
    [SerializeField] private GameObject AddList;

    private bool isMove = false;
    private int MoveIndex = -1;
    void Start()
    {
        if (ColleagueSystem.Instance.GetDeck(DeckNum).Count == 0)
        {
            for (int i = ColleagueSystem.Instance.GetDeck(DeckNum).Count; i <= 4; i++)
            {
                ColleagueSystem.Instance.GetDeck(DeckNum).Add(null);
            }
        }
        OnColleagueOrganizationFunc();
        OnColleagueOrganization.onClick.AddListener(OnColleagueOrganizationFunc);
        OnColleagueList.onClick.AddListener(OnColleagueListFunc);

        LeftArrow.onClick.AddListener(LeftArrowFunc);
        RightArrow.onClick.AddListener(RightArrowFunc);

        Move.onClick.AddListener(MoveButtonFunc);
        MoveCancel.onClick.AddListener(MoveCancelButtonFunc);

        AllClear.onClick.AddListener(AllClearFunc);
    }
    private void OnColleagueOrganizationFunc()
    {
        isMove = false;
        MoveState.SetActive(false);
        MoveCancel.gameObject.SetActive(false);
        ColleagueOrganizationObject.SetActive(true);
        if(ColleagueListObject.activeSelf) ColleagueListObject.SetActive(false);

        for(int i = 0;i < 5;i++)
        {
            int n = i;
            
            DeckList[i].onClick.AddListener(() => DeckListFunc(n));
            DeckInfo[i].gameObject.SetActive(false);
            DeckClear[i].gameObject.SetActive(false);
            if (ColleagueSystem.Instance.GetDeck(DeckNum).Count <= i)
            {
                DeckList[i].transform.GetChild(1).GetComponent<Text>().text = "+";
                DeckList[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                continue;
            }
            if (ColleagueSystem.Instance.GetDeck(DeckNum)[i] != null)
            {
                Debug.Log(ColleagueSystem.Instance.GetDeck(DeckNum)[i].name);
                
                
                DeckList[i].transform.GetChild(1).GetComponent<Text>().text = ColleagueSystem.Instance.GetDeck(DeckNum)[i].name;
                DeckList[i].transform.GetChild(0).GetComponent<Image>().sprite = image[(int)ColleagueSystem.Instance.GetDeck(DeckNum)[i].club];
                //DeckInfo[i].gameObject.SetActive(true);
                DeckClear[i].gameObject.SetActive(true);
                DeckClear[i].onClick.RemoveAllListeners();
                DeckClear[i].onClick.AddListener(() => DeckClearButtonFunc(n));
                continue;
            }
            else
            {
                DeckList[i].transform.GetChild(1).GetComponent<Text>().text = "+";
                DeckList[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
    }
    private void MoveButtonFunc()
    {
        MoveIndex = -1;
        MoveCancel.gameObject.SetActive(true);
        MoveState.SetActive(true);
        isMove = true;
    }
    private void MoveCancelButtonFunc()
    {
        isMove = false;
        MoveState.SetActive(false);
        MoveIndex = -1;
        MoveCancel.gameObject.SetActive(false);
    }
    private void OnColleagueListFunc()
    {
        ColleagueListObject.SetActive(true);
        if (ColleagueOrganizationObject.activeSelf) ColleagueOrganizationObject.SetActive(false);

        isMove = false;
        MoveState.SetActive(false);
        MoveCancel.gameObject.SetActive(false);
    }
    private void LeftArrowFunc()
    {
        if(DeckNum == 0)
        {
            DeckNum= 4;
        }    
        else
        {
            DeckNum--;
        }
        OnColleagueOrganizationFunc();
        DeckNumber.text = "파티 " + (DeckNum+1);
        if (ColleagueSystem.Instance.GetDeck(DeckNum).Count == 0)
        {
            for (int i = ColleagueSystem.Instance.GetDeck(DeckNum).Count; i <= 4; i++)
            {
                ColleagueSystem.Instance.GetDeck(DeckNum).Add(null);
            }
        }
    }
    private void RightArrowFunc()
    {
        if (DeckNum == 4)
        {
            DeckNum = 0;
        }
        else
        {
            DeckNum++;
        }
        OnColleagueOrganizationFunc();
        DeckNumber.text = "파티 " + (DeckNum + 1);
        if(ColleagueSystem.Instance.GetDeck(DeckNum).Count == 0)
        {
            for (int i = ColleagueSystem.Instance.GetDeck(DeckNum).Count; i <= 4; i++)
            {
                ColleagueSystem.Instance.GetDeck(DeckNum).Add(null);
            }
        }
        
    }
    private void AllClearFunc()
    {
        ColleagueSystem.Instance.DeckClear(DeckNum);
        effect.Guide(Guide, "초기화 되었습니다", 0.5f);
        OnColleagueOrganizationFunc();
    }

    private void DeckListFunc(int index)
    {
        if (isMove)
        {
            
            if (MoveIndex == -1)
            {
                
                if (ColleagueSystem.Instance.GetDeck(DeckNum)[index] != null)
                {
                    effect.Guide(Guide, "선택 되었습니다", 0.5f);
                    MoveIndex = index;
                }
                return;
            }
            else if (MoveIndex != index) 
            {
                effect.Guide(Guide, "이동 되었습니다", 0.5f);
                ColleagueSystem.Instance.Swap(DeckNum, index, MoveIndex);
                OnColleagueOrganizationFunc();
                MoveCancelButtonFunc();
                return;
            }
            return;
        }
        if (ColleagueSystem.Instance.GetDeck(DeckNum).Count <= index)
        {
            
            
            SeletCharacter(index);
            return;
        }
        if (ColleagueSystem.Instance.GetDeck(DeckNum)[index] != null)
        {
            Debug.Log(ColleagueSystem.Instance.GetDeck(DeckNum)[index].name);
        }
        else
        {
            SeletCharacter(index);
            //추가
        }
    }
    private void SeletCharacter(int index)
    {
        AddList.SetActive(true);
        effect.Typing(BackText, "동료 리스트", 0.1f);
        AllButtonFunc(index);
        AllButton.onClick.RemoveAllListeners();
        AllButton.onClick.AddListener(()=>AllButtonFunc(index));
        ColleagueType type = ColleagueType.Attack;
        AttackButton.onClick.RemoveAllListeners();
        AttackButton.onClick.AddListener(() => TypeButtonFunc(index, type));
        ColleagueType dtype = ColleagueType.Debuff;
        DebuffButton.onClick.RemoveAllListeners();
        DebuffButton.onClick.AddListener(() => TypeButtonFunc(index, dtype));
        ColleagueType stype = ColleagueType.Support;
        SupportButton.onClick.RemoveAllListeners();
        SupportButton.onClick.AddListener(() => TypeButtonFunc(index, stype));
    }
    private void AllButtonFunc(int num)
    {
        int index = 0;
        List<Colleague>  colleagues = ColleagueSystem.Instance.Getcolleagues();
        for (int i = 0; i <ColleagueListButton.Count; i++)
        {
            ColleagueListButton[i].gameObject.SetActive(false);
            if (i >= colleagues.Count)
            {
                ColleagueListButton[i].gameObject.SetActive(false);
                continue;
            }
            else
            {
                if (ColleagueSystem.Instance.IsInList(DeckNum, colleagues[i].name))
                {
                    ColleagueListButton[i].gameObject.SetActive(false);
                }
                else
                {
                    ColleagueListButton[index].gameObject.SetActive(true);
                    SetListCharacter(index, num, colleagues[i]);
                    index++;
                    
                    continue;
                }


            }
            

        }
    }
    private void TypeButtonFunc(int num,ColleagueType type)
    {
        int index = 0;
        List<Colleague> colleagues = ColleagueSystem.Instance.Getcolleagues();
        for (int i = 0; i < ColleagueListButton.Count; i++)
        {
            ColleagueListButton[i].gameObject.SetActive(false);
            if (i >= colleagues.Count)
            {
                ColleagueListButton[i].gameObject.SetActive(false);
                continue;
            }
            else if (colleagues[i].type == type)
            {
                if (ColleagueSystem.Instance.IsInList(DeckNum, colleagues[i].name))
                {
                    ColleagueListButton[i].gameObject.SetActive(false);
                }
                else
                {
                    ColleagueListButton[index].gameObject.SetActive(true);
                    SetListCharacter(index, num, colleagues[i]);
                    index++;
                }


            }

        }
    }
    private void SetListCharacter(int Deckindex,int index, Colleague Character)
    {
        ColleagueListButton[Deckindex].transform.GetChild(1).GetComponent<Text>().text = Character.name;
        ColleagueListButton[Deckindex].transform.GetChild(0).GetComponent<Image>().sprite = image[(int)Character.club];
        ColleagueListButton[Deckindex].onClick.RemoveAllListeners();
        ColleagueListButton[Deckindex].onClick.AddListener(() => AddDeckCharacter(index, Character));
    }
    private void AddDeckCharacter(int index,Colleague Character)
    {
        ColleagueSystem.Instance.Add(DeckNum,index, Character);
        OnColleagueOrganizationFunc();
        AddList.SetActive(false);
    }
    private void DeckClearButtonFunc(int index)
    {
        ColleagueSystem.Instance.Add(DeckNum,index, null);
        OnColleagueOrganizationFunc();
    }
}
