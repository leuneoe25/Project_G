using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSystem : MonoBehaviour
{
    [SerializeField] private Button BackButton;

    [Header("Goods Text")]
    [SerializeField] private Text SP_text;
    [SerializeField] private Text[] Buildingtext;
    [Header("Type")]
    [SerializeField] private Button PackageButton;
    [SerializeField] private Button BuildingGoodsButton;
    [SerializeField] private Button clystalButton;

    [SerializeField] private SceneManagement scene;
    void Start()
    {
        //GoodsSystem.Instance.SetBuildingGoods(101, 101, 101);
        //GoodsSystem.Instance.SetSP(100);

        SP_text.text = GoodsSystem.Instance.GetSP().ToString();
        for (int i = 0; i < Buildingtext.Length; i++)
        {
            Buildingtext[i].text = GoodsSystem.Instance.GetBuildingGoods(i).ToString();
        }
        BackButton.onClick.AddListener(BackButtonFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadGoods(string s)
    {
        string[] goods = new string[7];
        int index = 0;
        for(int i=0;i<s.Length;i++)
        {
            if(s[i] != ' ')
            {
                goods[index] += s[i];
            }
            else
            {
                index++;
            }
        }

        GoodsSystem.Instance.SetSP(Convert.ToInt32(goods[0]));
    }
    private void BackButtonFunc()
    {
        scene.LoadMenu();
    }
}
