using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSaver : MonoBehaviour
{
    [SerializeField] private  GameObject backButtonObject;
    [SerializeField] Button[] buttons;
    [SerializeField] ButtonList buttonList;
    [SerializeField] ButtonAnimation buttonAnimation;
    [SerializeField] private SceneManagement scene;
    [Header("MapInfo")]
    [SerializeField] private GameObject UI;
    [SerializeField] private Button EnterInGameButton;


    private void Start()
    {
        backButtonObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(BackButtonFunc);
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

    }

    void ButtonFunc(int num)
    {
        UI.SetActive(true);
        EnterInGameButton.onClick.AddListener(scene.LoadGameScene);
        EffectSystem.Instance.ExcutTyping(backButtonObject.transform.GetChild(1).GetComponent<Text>(), "입장", 0.1f);
        
        //buttonAnimation.UnlockNextStage(num);
    }
    void BackButtonFunc()
    {
        if(UI.activeSelf)
        {
            UI.SetActive(false);
            EffectSystem.Instance.ExcutTyping(backButtonObject.transform.GetChild(1).GetComponent<Text>(), "수호", 0.1f);
        }
        else
        {
            //게임 메뉴로
            scene.LoadMenu();
        }
    }

    public void LockOn(int num)
    {
        buttonList.buttons[num].gameObject.SetActive(true);
    }

}
