using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameMenuUI : MonoBehaviour
{
    [SerializeField] private SceneManagement scene;
    [Header("Goods Text")]
    [SerializeField] private Text SP_text;
    [SerializeField] private Text[] Buildingtext;

    [SerializeField] private Button StoreButton;
    void Start()
    {
        StoreButton.onClick.AddListener(scene.LoadStore);

        SP_text.text = GoodsSystem.Instance.GetSP().ToString();
        for(int i = 0; i < Buildingtext.Length;i++)
        {
            Buildingtext[i].text = GoodsSystem.Instance.GetBuildingGoods(i).ToString();
        }
    }
}
