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
            text[0].text = "���Ƹ� : " + ((ColleagueClub)kk).ToString();
            FriendImage.sprite = image[kk];
            text[1].text = "���� \n\n��" + 10 * GoodsSystem.Instance.GSetCouncilLv() + "\nü��" + 10 * GoodsSystem.Instance.GSetCouncilLv() + "\n����" + 10 * GoodsSystem.Instance.GSetCouncilLv();

        }
    }
}
