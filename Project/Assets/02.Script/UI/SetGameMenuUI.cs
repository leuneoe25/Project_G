using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameMenuUI : MonoBehaviour
{
    [Header("Goods Text")]
    [SerializeField] private Text SP_text;
    [SerializeField] private Text[] Buildingtext;
    [Header("EnterStore")]
    [SerializeField] private Button EnterStoreButton;
    [SerializeField] private SceneManagement scene;
    void Start()
    {
        GoodsSystem.Instance.SetBuildingGoods(101, 101, 101);
        GoodsSystem.Instance.SetSP(100);

        SP_text.text = GoodsSystem.Instance.GetSP().ToString();
        for(int i = 0; i < Buildingtext.Length;i++)
        {
            Buildingtext[i].text = GoodsSystem.Instance.GetBuildingGoods(i).ToString();
        }
        EnterStoreButton.onClick.AddListener(EnterButtonFunc);
    }
    private void EnterButtonFunc()
    {
        scene.LoadStore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
