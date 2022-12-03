using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSaver : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [Header("Back")]
    [SerializeField] private Button BackButton;
    [SerializeField] private Text BackText;
    [SerializeField] private Button EnterStageButton;
    [SerializeField] private Image Map;

    [SerializeField] private SceneManagement scene;
    [SerializeField] private EffectSystem effect;

    [SerializeField] Button[] buttons;
    [SerializeField] ButtonList buttonList;
    [SerializeField] ButtonAnimation buttonAnimation;


    private void Start()
    {
        buttonList = GetComponent<ButtonList>();    
        for(int i = 0; i < buttons.Length; ++i)
        {
            buttonList.Add(buttons[i]);
            int a = i;
            buttonList.buttons[i].onClick.AddListener(() => ButtonFunc(a));
            if(i != 0)
            {
                buttonList.buttons[i].gameObject.SetActive(false);
            }
        }

        BackButton.onClick.AddListener(BackButtonFunc);
        EnterStageButton.onClick.AddListener(EnterStageButtonFunc);
    }

    void ButtonFunc(int num)
    {
        PlayerPrefs.SetInt("StageLevel", num);
        effect.Typing(BackText, "스테이지 입장", 0.1f);
        UI.SetActive(true);
    }
    private void BackButtonFunc()
    {
        if(UI.activeSelf)
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
        scene.LoadGameScene();
    }
    public void LockOn(int num)
    {
        buttonList.buttons[num].gameObject.SetActive(true);
    }

}
