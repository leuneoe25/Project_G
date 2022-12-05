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
        ColleagueSystem.Instance.AddColleague(name, GoodsSystem.Instance.GSetCouncilLv(), new int[3] { 0, 0, 0}, (ColleagueClub)kk);
        gameObject.SetActive(false);
    }


    void Start()
    {
        button.onClick.AddListener(() => PushButton());
    }
    void Update()
    {
        if(gameObject.activeSelf)
        {
            kk = Random.Range(0, 9);
            text[0].text = "동아리 : " + ((ColleagueClub)kk).ToString();
            FriendImage.sprite = image[kk];
            text[1].text = "스탯 \n\n힘" + 10 * GoodsSystem.Instance.GSetCouncilLv() + "\n체력" + 10 * GoodsSystem.Instance.GSetCouncilLv() + "\n방어력" + 10 * GoodsSystem.Instance.GSetCouncilLv();

        }
    }
}
