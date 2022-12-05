using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Arr
{
    public int[] needsEle = new int[3];
}

public class CouncilLv : MonoBehaviour
{
    int maxLv = 3;
    [SerializeField] Text ButtonText;
    [SerializeField] Text text;
    [SerializeField] Text[] NeedsEle;
    [SerializeField] Button button;
    public Arr[] NeedsCouncil;
    public int councilLevel = 1;
    bool[] check = new bool[3];
    bool max;
    string[] txt = new string[3] { "¸ñÀç", "À¯¸®", "Ã¶" };


    void Start()
    {
        councilLevel = GoodsSystem.Instance.GSetCouncilLv();
        SetText();
        button.onClick.AddListener(() => CouncilLvUp());
    }


    void Update()
    {

    }
    void CouncilLvUp()
    {
        if (!max)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (GoodsSystem.Instance.GetBuildingGoods(i) > NeedsCouncil[councilLevel - 1].needsEle[i])
                {
                    check[i] = true;
                }
            }
            if (check[0] && check[1] && check[2])
            {
                GoodsSystem.Instance.SetBuildingGoods((-1 * NeedsCouncil[councilLevel - 1].needsEle[0]), (-1 * NeedsCouncil[councilLevel - 1].needsEle[1]), (-1 * NeedsCouncil[councilLevel - 1].needsEle[2]));
                councilLevel++;
                GoodsSystem.Instance.GSetCouncilLv(1);
                SetText();
                Debug.Log("LvUp");
            }
        }
    }
    void SetText()
    {
        if (councilLevel == maxLv)
        {
            ButtonText.text = "MAX";
            max = true;
        }
        text.text = councilLevel.ToString();
        for (int i = 0; i < 3; ++i)
        {
            NeedsEle[i].text = txt[i] + GoodsSystem.Instance.GetBuildingGoods(i) + "/" + NeedsCouncil[councilLevel - 1].needsEle[i];
        }

    }
}
