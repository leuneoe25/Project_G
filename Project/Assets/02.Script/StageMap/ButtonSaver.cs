using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSaver : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [Header("Back")]
    [SerializeField] private Button BackButton;
    [SerializeField] private Text BackText;
    [SerializeField] private Button EnterStageButton;
    [SerializeField] private GameObject World;

    [SerializeField] private SceneManagement scene;
    [SerializeField] private EffectSystem effect;

    [SerializeField] Button[] buttons;
    [SerializeField] ButtonList buttonList;
    [SerializeField] ButtonAnimation buttonAnimation;
    [SerializeField] PartyManagement party;


    private void Start()
    {
        buttonList = GetComponent<ButtonList>();
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttonList.Add(buttons[i]);
            int a = i;
            buttonList.buttons[i].onClick.AddListener(() => ButtonFunc(a));
            buttonList.buttons[i].gameObject.SetActive(ClearChack.Instance.IsOpen(i));
        }

        BackButton.onClick.AddListener(BackButtonFunc);
        EnterStageButton.onClick.AddListener(EnterStageButtonFunc);
    }

    void ButtonFunc(int num)
    {
        PlayerPrefs.SetInt("StageLevel", num);
        effect.Typing(BackText, "스테이지 입장", 0.1f);
        World.transform.GetChild(0).GetComponent<Text>().text = "월드 " + (num + 1);
        World.transform.GetChild(1).GetComponent<Text>().text = buttons[num].GetComponentInChildren<Text>().text + " 수호";
        World.transform.GetChild(2).GetComponent<MapImage>().ImageChange(num);

        party.SetParty();

        UI.SetActive(true);
    }
    private void BackButtonFunc()
    {
        if (UI.activeSelf)
        {
            effect.Typing(BackText, "수호", 0.1f);
            UI.SetActive(false);
        }
        else
        {
            scene.LoadMenu();
        }
    }
    private void EnterStageButtonFunc()
    {
        PlayerPrefs.SetInt("PartyNum", party.Index);
        scene.LoadGameScene();
    }
    public void LockOn(int num)
    {
        buttonList.buttons[num].gameObject.SetActive(true);
    }
}
