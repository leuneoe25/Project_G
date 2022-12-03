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
    [Header("Product")]
    [SerializeField] private List<Button> products;

    [SerializeField] private SceneManagement scene;

    string[,] TitleProduct = new string[3, 4];
    Dictionary<string, string> Products;
    void Start()
    {
        AddProduct();
        SetProduct(0);
        //GoodsSystem.Instance.SetBuildingGoods(101, 101, 101);
        //GoodsSystem.Instance.SetSP(100);

        SP_text.text = GoodsSystem.Instance.GetSP().ToString();
        for (int i = 0; i < Buildingtext.Length; i++)
        {
            Buildingtext[i].text = GoodsSystem.Instance.GetBuildingGoods(i).ToString();
        }
        BackButton.onClick.AddListener(BackButtonFunc);

        PackageButton.onClick.AddListener(()=>SetProduct(0));
        BuildingGoodsButton.onClick.AddListener(()=>SetProduct(1));
        clystalButton.onClick.AddListener(()=>SetProduct(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddProduct()
    {

        Products = new Dictionary<string, string>();
        TitleProduct[0, 0] = "기초패키지";
        Products.Add(TitleProduct[0, 0], "100");

        //Packageproduct.Add(new Product("기초패키지", "100"));

        TitleProduct[1, 0] = "목재 구매(10)100SP";
        Products.Add(TitleProduct[1,0], "-100 10");
        TitleProduct[1, 1] = "유리 구매(10)100SP";
        Products.Add(TitleProduct[1, 1], "-100 0 10");
        TitleProduct[1, 2] = "철제 구매(10)100SP";
        Products.Add(TitleProduct[1, 2], "-100 0 0 10");

        TitleProduct[2, 0] = "공격형 보석 구매(10)100SP";
        Products.Add(TitleProduct[2, 0], "-100 0 0 0 10");
        TitleProduct[2, 1] = "디버프형 보석 구매(10)100SP";
        Products.Add(TitleProduct[2, 1], "-100 0 0 0 0 10");
        TitleProduct[2, 2] = "지원형 보석 구매(10)100SP";
        Products.Add(TitleProduct[2, 2], "-100 0 0 0 0 0 10");

    }
    private void SetProduct(int index)
    {
        if(TitleProduct[index,0] != null)
        {
            for(int i = 0; i<4;i++)
            {
                if (TitleProduct[index,i] == null)
                {
                    products[i].gameObject.SetActive(false);
                    continue;
                }
                products[i].gameObject.SetActive(true);
                products[i].gameObject.transform.GetChild(0).GetComponent<Text>().text = TitleProduct[index,i];
                products[i].onClick.RemoveAllListeners();
                string s = TitleProduct[index, i];
                products[i].onClick.AddListener(() => ReadGoods(Products[s]));
                
            }
        }
    }


    private void ReadGoods(string s)
    {
        string[] goods = new string[7] { "0", "0", "0", "0", "0", "0", "0"};
        int index = 0;
        goods[0] = "";
        for (int i=0;i<s.Length;i++)
        {
            if(s[i] != ' ')
            {
                goods[index] += s[i];
            }
            else
            {
                index++;
                goods[index] = "";
            }
        }

        GoodsSystem.Instance.SetSP(Convert.ToInt32(goods[0]));
        GoodsSystem.Instance.SetBuildingGoods(Convert.ToInt32(goods[1]), Convert.ToInt32(goods[2]), Convert.ToInt32(goods[3]));
        GoodsSystem.Instance.SetCrystals(Convert.ToInt32(goods[4]), Convert.ToInt32(goods[5]), Convert.ToInt32(goods[6]));

        SP_text.text = GoodsSystem.Instance.GetSP().ToString();
        for (int i = 0; i < Buildingtext.Length; i++)
        {
            Buildingtext[i].text = GoodsSystem.Instance.GetBuildingGoods(i).ToString();
        }
    }
    private void BackButtonFunc()
    {
        scene.LoadMenu();
    }
}
