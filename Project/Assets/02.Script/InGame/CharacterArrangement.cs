using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using System.ComponentModel;
using UnityEngine.UI;

public class CharacterArrangement : MonoBehaviour
{
    //��ġ�ο�
    [SerializeField] private int DeployPeople = 4;
    private int nowDeployPeople = 1;
    [SerializeField] private CinemachineClearShot clearShot;
    //��ġ ī�� �迭
    [SerializeField] private GameObject[] CharacterCardList;
    //��ġ�� ĳ���� ������ ����Ʈ
    [SerializeField] private List<GameObject> objects;
    //���� ī�޶�
    [SerializeField] private Camera mainCamera;
    //������ ��ũ��Ʈ�� ����ִ� ������Ʈ
    [SerializeField] private GameObject moveManager;
    //Nullī�޶� ������ ����
    [SerializeField] private Queue<GameObject> NullCameraList = new Queue<GameObject>();
    public bool isArrangement = false;

    private List<Colleague> CharacterList;
    [SerializeField] private Sprite[] CharacterImage;
    [SerializeField] private Text setedChar;
    private int partyIndex;
    private bool[] isSet = new bool[5];
    private int[] characterNumber = new int[5];
    private int setChar = 0;

    [SerializeField] private GameObject effectSystem;
    [SerializeField] private Text SetedText;

    void Start()
    {
        setedChar.text = "��ġ�� ĳ���� : " + setChar;

        partyIndex = PlayerPrefs.GetInt("PartyNum");
        CharacterList = ColleagueSystem.Instance.GetDeck(partyIndex);
        DeployPeople = CharacterList.Count;
        for (int i = 0; i < CharacterList.Count; i++)
        {
            if (CharacterList[i] != null) characterNumber[i] = (int)CharacterList[i].club;
            else characterNumber[i] = 9;
        }

        SetCard();
        for (int i = 0; i < clearShot.ChildCameras.Length; i++)
        {
            if (clearShot.ChildCameras[i].name == "Null")
            {
                Debug.Log(i);
                NullCameraList.Enqueue(clearShot.ChildCameras[i].gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetCard()
    {
        if (DeployPeople > CharacterCardList.Length)
        {
            Debug.Log("���� ��ġ �ο��� �����ϴ�");
            DeployPeople = CharacterCardList.Length;
        }
        else if (DeployPeople != CharacterCardList.Length)
        {
            for (int i = 0; i < DeployPeople; i++)
            {
                CharacterCardList[i].GetComponent<Image>().sprite = CharacterImage[characterNumber[i]];
            }
            for (int i = DeployPeople; i < CharacterCardList.Length; i++)
            {
                CharacterCardList[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < DeployPeople; i++)
            {
                CharacterCardList[i].GetComponent<Image>().sprite = CharacterImage[characterNumber[i]];
            }
        }

        EventTrigger.Entry entryTrigger = new EventTrigger.Entry();

        for (int i = 0; i < DeployPeople; i++)
        {
            //temporary var
            GameObject v = CharacterCardList[i];
            //Enter Pointer
            entryTrigger = new EventTrigger.Entry();
            entryTrigger.eventID = EventTriggerType.PointerEnter;
            entryTrigger.callback.AddListener((data) => { EnterCard(v); });
            v.GetComponent<EventTrigger>().triggers.Add(entryTrigger);

            //Exit Pointer
            entryTrigger = new EventTrigger.Entry();
            entryTrigger.eventID = EventTriggerType.PointerExit;
            entryTrigger.callback.AddListener((data) => { ExitCard(v); });
            v.GetComponent<EventTrigger>().triggers.Add(entryTrigger);

            //Exit Pointer
            entryTrigger = new EventTrigger.Entry();
            entryTrigger.eventID = EventTriggerType.PointerDown;
            int _v = i;
            entryTrigger.callback.AddListener((data) => { CreateCharacter(_v); });
            v.GetComponent<EventTrigger>().triggers.Add(entryTrigger);
        }
        //CharacterCardList
    }
    private void EnterCard(GameObject card)
    {
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + 1, card.transform.position.z);
    }
    private void ExitCard(GameObject card)
    {
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - 1, card.transform.position.z);
    }

    private void CreateCharacter(int index)
    {
        if (!isSet[index])
        {
            isSet[index] = true;
            setChar++;
            setedChar.text = "��ġ�� ĳ���� : " + setChar;
            if (null == moveManager.GetComponent<MovePosition>().selected)
            {
                GameObject Char = Instantiate(objects[characterNumber[index]], mainCamera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                GameObject C = NullCameraList.Dequeue();
                //Char.name = "ĳ����";
                C.SetActive(true);
                C.transform.position = Char.transform.position;
                C.name = Char.name;
                C.GetComponent<CinemachineVirtualCamera>().Follow = Char.transform;
                moveManager.GetComponent<MovePosition>().SetPosition(Char);
                isArrangement = true;

            }
        }
        else
        {
            effectSystem.GetComponent<EffectSystem>().Guide(SetedText, "�̹� ��ġ�� �����Դϴ�", 1);
        }
    }
}
