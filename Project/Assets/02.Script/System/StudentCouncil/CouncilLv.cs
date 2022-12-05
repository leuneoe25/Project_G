using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CouncilLv : MonoBehaviour
{
    int maxLv = 5;
    [SerializeField] Text ButtonText;
    [SerializeField] Text text;
    [SerializeField] Text[] NeedsEle;
    [SerializeField] Button button;
    int[,] NeedsCouncil = new int[6, 3];
    public int councilLevel = 1;
    bool[] check = new bool[3];
    bool max;
    string[] txt = new string[3] { "¸ñÀç", "À¯¸®", "Ã¶" };


    void Start()
    {
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
                if (GoodsSystem.Instance.GetBuildingGoods(i) > NeedsCouncil[councilLevel, i])
                {
                    check[i] = true;
                }
            }
            if (check[0] && check[1] && check[2])
            {
                GoodsSystem.Instance.SetBuildingGoods((-1 * NeedsCouncil[councilLevel, 0]), (-1 * NeedsCouncil[councilLevel, 1]), (-1 * NeedsCouncil[councilLevel, 2]));
                councilLevel++;
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
            NeedsEle[i].text = txt[i] + GoodsSystem.Instance.GetBuildingGoods(i) + "/" + NeedsCouncil[councilLevel, i];
        }

    }
}
