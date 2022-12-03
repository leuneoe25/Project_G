using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ColleagueList : MonoBehaviour
{
    [SerializeField] private Button BackButton;
    [SerializeField] private Text BackText;
    [SerializeField] private SceneManagement scene;
    [SerializeField] private EffectSystem effect;
    [SerializeField] private Text Guide;
    [Header("Type Button")]
    [SerializeField] private Button AllButton;
    [SerializeField] private Button AttackButton;
    [SerializeField] private Button DebuffButton;
    [SerializeField] private Button SupportButton;
    [Header("ListObject")]
    [SerializeField] private List<GameObject> colleagueList;
    [Header("colleagueInfo")]
    [SerializeField] private GameObject colleagueInfoUI;
    [SerializeField] private GameObject rank;
    [SerializeField] private Text name;
    [SerializeField] private GameObject Type;
    [SerializeField] private Sprite[] icon;
    [Header("Stat")]
    [SerializeField] private Text[] Stat;
    [Header("colleagueInfoList")]
    [SerializeField] private List<GameObject> colleagueInfoList;

    [Header("Enfoce")]
    [SerializeField] private Button RankUpButton;
    [SerializeField] private Button TrainingButton;

    [Header("RankUp")]
    [SerializeField] private GameObject RankUpUI;
    [SerializeField] private GameObject MaxImage;
    [SerializeField] private Text[] RankText;
    [SerializeField] private Text[] Crystal;
    [SerializeField] private Text[] NowStat;
    [SerializeField] private Text[] AfterStat;
    [SerializeField] private Text NeedCrystal;
    [SerializeField] private Button ExcutRankUp;

    [Header("Training")]
    [SerializeField] private GameObject TrainingUI;
    [SerializeField] private Text[] TrainingStat;
    [SerializeField] private Text Explanation;
    [SerializeField] private Button FulReinforcement;
    [SerializeField] private Button OneReinforcement;
    [SerializeField] private Button ConcentrationReinforcement;


    private List<Colleague> colleagues;
    void Start()
    {
        colleagues = ColleagueSystem.Instance.Getcolleagues();
        AllButtonFunc();
        AllButton.onClick.AddListener(AllButtonFunc);
        AttackButton.onClick.AddListener(AttackButtonFunc);
        DebuffButton.onClick.AddListener(DebuffButtonFunc);
        SupportButton.onClick.AddListener(SupportButtonFunc);

        BackButton.onClick.AddListener(BackButtonFunc);
    }
    private void BackButtonFunc()
    {
        if(colleagueInfoUI.activeSelf)
        {
            if (TrainingUI.activeSelf)
            {
                TrainingUI.SetActive(false);
                effect.Typing(BackText, "동료 스탯", 0.1f);
                return;
            }
            else if(RankUpUI.activeSelf)
            {
                RankUpUI.SetActive(false);
                effect.Typing(BackText, "동료 스탯", 0.1f);
                return;
            }
            effect.Typing(BackText, "동료 리스트", 0.1f);
            colleagueInfoUI.SetActive(false);
            return;
        }
        else
        {
            scene.LoadMenu();
        }
    }
    void AllButtonFunc()
    {
        for (int i = 0; i < colleagueList.Count; i++)
        {
            if (i>= colleagues.Count)
            {
                colleagueList[i].SetActive(false);
                continue;
            }
            else
            {
                colleagueList[i].SetActive(true);
                SetListCharacter(i, i);
            }

        }
    }
    void AttackButtonFunc()
    {
        int index = 0;
        for (int i = 0; i < colleagueList.Count; i++)
        {
            
            if (i >= colleagues.Count) 
            {
                colleagueList[i].SetActive(false);
                continue;
            }
            else if (colleagues[i].type == ColleagueType.Attack)
            {
                colleagueList[index].SetActive(true);
                SetListCharacter(index, i);
                index++;
                continue;
            }
            colleagueList[i].SetActive(false);
        }
    }
    void DebuffButtonFunc()
    {
        int index = 0;
        for (int i = 0; i < colleagueList.Count; i++)
        {

            if (i >= colleagues.Count)
            {
                colleagueList[i].SetActive(false);
                continue;
            }
            else if (colleagues[i].type == ColleagueType.Debuff)
            {
                colleagueList[index].SetActive(true);
                SetListCharacter(index, i);
                index++;
                continue;
            }
            colleagueList[i].SetActive(false);
        }
    }
    void SupportButtonFunc()
    {
        int index = 0;
        for (int i = 0; i < colleagueList.Count; i++)
        {

            if (i >= colleagues.Count)
            {
                colleagueList[i].SetActive(false);
                continue;
            }
            else if (colleagues[i].type == ColleagueType.Support)
            {
                colleagueList[index].SetActive(true);
                SetListCharacter(index, i);
                index++;
                continue;
            }
            colleagueList[i].SetActive(false);
        }
    }
    private void SetListCharacter(int listIndex, int colleaguesIndex)
    {
        
        colleagueList[listIndex].transform.GetChild(1).GetComponent<Text>().text = colleagues[colleaguesIndex].name;
        colleagueList[listIndex].GetComponent<Button>().onClick.RemoveAllListeners();
        colleagueList[listIndex].GetComponent<Button>().onClick.AddListener(() => SetColleagueInfo(colleagues[colleaguesIndex]));
        RankUpUI.SetActive(false);
        TrainingUI.SetActive(false);
    }
    private void SetColleagueInfo(Colleague Character)
    {
        effect.Typing(BackText, "동료 스탯", 0.1f);
        colleagueInfoUI.SetActive(true);
        
        for (int i = 0; i < 5; i++)
        {
            if (Character.rank > i)
            {
                rank.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                rank.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        name.text = Character.name;
        //아이콘
        //Type.transform.GetChild(0).GetComponent<Image>().sprite = icon[(int)Character.type];
        Type.transform.GetChild(1).GetComponent<Text>().text = Character.type.ToString();

        for (int i = 0; i < 3; i++)
        {
            Stat[i].text = ((10 * Character.rank) + Character.training[i]).ToString();
        }

        RankUpButton.onClick.RemoveAllListeners();
        RankUpButton.onClick.AddListener(()=>SetRankUpButtonFunc(Character));
        TrainingButton.onClick.RemoveAllListeners();
        TrainingButton.onClick.AddListener(SetTrainingButtonFunc);

        SetColleagueInfoList(Character);
    }
    private void SetColleagueInfoList(Colleague Character)
    {
        int index = 0;
        for (int i = 0; i < colleagueInfoList.Count; i++)
        {

            if (i >= colleagues.Count)
            {
                colleagueInfoList[i].SetActive(false);
                continue;
            }
            else if (colleagues[i].name != Character.name)
            {
                colleagueInfoList[index].SetActive(true);
                colleagueInfoList[index].transform.GetChild(0).GetComponent<Text>().text = colleagues[i].name;
                colleagueInfoList[index].GetComponent<Button>().onClick.RemoveAllListeners();
                Colleague c = colleagues[i];
                colleagueInfoList[index].GetComponent<Button>().onClick.AddListener(() => SetColleagueInfo(c));
                //SetColleagueInfo(index, i);
                index++;
                continue;
            }
            colleagueInfoList[i].SetActive(false);
        }
        
    }
    private void SetRankUpButtonFunc(Colleague Character)
    {
        effect.Typing(BackText, "동료 승급", 0.1f);
        RankUpUI.SetActive(true);
        if (Character.rank == 5)
        {
            MaxImage.SetActive(true);
            RankText[0].text = "Rank."+Character.rank.ToString();
            RankText[1].text = "";
        }
        else
        {
            RankText[0].text = "Rank." + Character.rank.ToString();
            RankText[1].text = "Rank." + (Character.rank+1).ToString(); ;
            MaxImage.SetActive(false);
        }
        SetCrystal();
        for (int i = 0; i < 3; i++)
        {
            NowStat[i].text = ((10*Character.rank) + (Character.training[i])).ToString();
            AfterStat[i].text = ((10 * (Character.rank+1)) + (Character.training[i])).ToString();
        }
        int need = 10;
        for(int i=0;i<Character.rank;i++)
        {
            need += need;
        }
        
        NeedCrystal.text = "필요 "+ Character.type .ToString()+ " 보석 : " + GoodsSystem.Instance.GetCrystals((int)Character.type) + "/" + need;
        ExcutRankUp.onClick.RemoveAllListeners();
        ExcutRankUp.onClick.AddListener(()=> ExcutRankUpFunc(Character, need));
    }
    private void SetCrystal()
    {
        for(int i=0;i<3;i++)
        {
            Crystal[i].text = GoodsSystem.Instance.GetCrystals(i).ToString();
        }
    }
    private void ExcutRankUpFunc(Colleague Character,int need)
    {
        if(need <= GoodsSystem.Instance.GetCrystals((int)Character.type))
        {
            if (Character.rank == 5)
            {
                effect.Guide(Guide, "최대 강화입니다", 1f);
                return;
            }
            Character.rank++;
            switch(Character.type)
            {
                case ColleagueType.Attack:
                    GoodsSystem.Instance.SetCrystals(-need, 0, 0);
                    break;
                case ColleagueType.Debuff:
                    GoodsSystem.Instance.SetCrystals(0, -need, 0);
                    break;
                case ColleagueType.Support:
                    GoodsSystem.Instance.SetCrystals(0, 0, -need);
                    break;
            }
            SetRankUpButtonFunc(Character);
            SetColleagueInfo(Character);

        }
        else
        {
            effect.Guide(Guide, "재화가 부족합니다", 1f);
            return;
        }
        
    }
    private void SetTrainingButtonFunc()
    {
        TrainingUI.SetActive(true);
        effect.Typing(BackText, "동료 훈련", 0.1f);
    }
}
