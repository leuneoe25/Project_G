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
    


    void CouncilLvUp()
    {
        if(!max)
        {
            for (int i = 0; i < 3; ++i)
            {
                //if(singleton.BaseEle[i] > NeedsCouncil[councilLevel][i])
                //{
                //check[i] = true;
                //}
            }
            //if(check[0] && check[1] && check[2])
            //{
            //for(int i = 0; i < 3; ++i)
            //{
            //singleton.BaseEle[i] -= NeedsCouncil[coumcilLevel][i];
            //}
            //councilLevel++;
            SetText();
            //}
            Debug.Log("LvUp");
        }
    }

    void SetText()
    {
        if(councilLevel == maxLv)
        {
            ButtonText.text = "MAX";
            max = true;
        }
        text.text = councilLevel.ToString();
        for(int i = 0; i < 3; ++i)
        {
            //NeedsEle[i].text = "¸ñÀç" + singleton.BaseEle[i] + "/" NeedsCouncil[councilLevel][i]
        }
    }

    void Start()
    {
        button.onClick.AddListener(() => CouncilLvUp());
    }


    void Update()
    {
        
    }
}
