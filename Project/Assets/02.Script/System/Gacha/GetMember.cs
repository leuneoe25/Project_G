using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMember : MonoBehaviour
{
    public Sprite[] image;
    [SerializeField] Text[] text;
    [SerializeField] InputField inputField;
    [SerializeField] Image FriendImage;
    [SerializeField] Button button;
    string name;
    int kk; 

    public void PushButton()
    {
        name = inputField.text;
        string a = name.Replace(" ", "");
        if (a != "")
        {
            GoodsSystem.Instance.SetSP(-1000);
            ColleagueSystem.Instance.AddColleague(name, GoodsSystem.Instance.GSetCouncilLv(), new int[3] { 0, 0, 0 }, (ColleagueClub)kk);
            kk = Random.Range(0, 9);
            inputField.text = "";
            gameObject.SetActive(false);
        }
    }


    void Start()
    {
        button.onClick.AddListener(() => PushButton());
        kk = Random.Range(0, 9);
    }
    void Update()
    {
        if(gameObject.activeSelf)
        {
            text[0].text = "���Ƹ� : " + ((ColleagueClub)kk).ToString();
            FriendImage.sprite = image[kk];
            text[1].text = "���� \n\n��" + 10 * GoodsSystem.Instance.GSetCouncilLv() + "\nü��" + 10 * GoodsSystem.Instance.GSetCouncilLv() + "\n����" + 10 * GoodsSystem.Instance.GSetCouncilLv();

        }
    }
}
