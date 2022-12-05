using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonLvUp : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    public int[] HpUPStat = { 0, };
    public float[] CostUp = { 0, };
    public float[] ReduceRecuitTime = { 0, };
    public string[] DefaultStr;

    int HpUp = 0;
    float BaseCostUp = 0;
    float ReduCeTime = 1;

    public int[] price;

    private bool[] LvMax = new bool[3];
    private int[] Lv = new int[3] { 1, 1, 1 };


    void SetText(int arrayAdress)
    {
        Text text = buttons[arrayAdress].transform.GetChild(1).GetComponent<Text>();
        text.text = DefaultStr[arrayAdress] + Lv[arrayAdress].ToString();
    }

    void HpLvUp()
    {
        if(!LvMax[0])
        {
            GoodsSystem.Instance.SetSP(-1 * price[Lv[0]]);
            Lv[0]++;
            GoodsSystem.Instance.GSetHpLv(1);
            HpUp = HpUPStat[Lv[0]];
            SetText(0);
            if(Lv[0] == HpUPStat.Length - 1)
            {
                LvMax[0] = true;
                Text text = buttons[0].transform.GetChild(0).GetComponent<Text>();
                text.text = "MAX";
            }
        }
    }

    void ReduceLvUp()
    {
        if (!LvMax[1])
        {
            GoodsSystem.Instance.SetSP(-1 * price[Lv[1]]);
            Lv[1]++;
            GoodsSystem.Instance.GSetReduceLv(1);
            ReduCeTime = ReduceRecuitTime[Lv[1]];
            SetText(1);
            if (Lv[1] == ReduceRecuitTime.Length - 1)
            {
                LvMax[1] = true;
                Text text = buttons[1].transform.GetChild(0).GetComponent<Text>();
                text.text = "MAX";
            }
        }
    }


    void CostLvUp()
    {
        if (!LvMax[2])
        {
            GoodsSystem.Instance.SetSP(-1 * price[Lv[2]]);
            Lv[2]++;
            GoodsSystem.Instance.GSetDefault(1);
            BaseCostUp = CostUp[Lv[2]];
            SetText(2);
            if (Lv[2] == CostUp.Length - 1)
            {
                LvMax[2] = true;
                Text text = buttons[2].transform.GetChild(0).GetComponent<Text>();
                text.text = "MAX";
            }
        }
    }

    void Start()
    {
        buttons[0].onClick.AddListener(() => HpLvUp());
        buttons[1].onClick.AddListener(() => ReduceLvUp());
        buttons[2].onClick.AddListener(() => CostLvUp());
        Lv[0] = GoodsSystem.Instance.GSetHpLv();
        Lv[1] = GoodsSystem.Instance.GSetReduceLv();
        Lv[2] = GoodsSystem.Instance.GSetDefault();
        for(int i = 0; i < 3; ++i)
        {
            if (Lv[i] == ReduceRecuitTime.Length - 1)
            {
                LvMax[i] = true;
                Text text = buttons[i].transform.GetChild(0).GetComponent<Text>();
                text.text = "MAX";
            }
        }
        for(int i = 0; i < 3; ++i)
        {
            SetText(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
