using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using System.ComponentModel;
using UnityEngine.UI;
using UnityEditor.Rendering;

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
    [SerializeField] private CostControl Cost;
    private GameObject[] Friends;

    void Start()
    {
        Friends = new GameObject[5];
        setedChar.text = "��ġ�� ĳ���� : " + setChar;

        partyIndex = PlayerPrefs.GetInt("PartyNum");
        CharacterList = ColleagueSystem.Instance.GetDeck(partyIndex);
        DeployPeople = CharacterList.Count;
        for (int i = 0; i < CharacterList.Count; i++)
        {
            if (CharacterList[i] != null)
            {
                characterNumber[i] = (int)CharacterList[i].club;
                CharacterCardList[i].GetComponentInChildren<Text>().text = CharacterList[i].name;
            }
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
            if (CharacterList[i] == null) continue;
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
            if (!Cost.UseCost(1))
            {
                effectSystem.GetComponent<EffectSystem>().Guide(SetedText, "�ڽ�Ʈ�� �����մϴ�.", 1);
                return;
            }
            isSet[index] = true;
            setChar++;
            setedChar.text = "��ġ�� ĳ���� : " + setChar;
            if (null == moveManager.GetComponent<MovePosition>().selected)
            {
                Friends[index] = Instantiate(objects[characterNumber[index]], mainCamera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                Friends[index].name = CharacterList[index].name;
                GameObject C = NullCameraList.Dequeue();
                //Char.name = "ĳ����";
                C.SetActive(true);
                C.transform.position = Friends[index].transform.position;
                C.name = Friends[index].name;
                C.GetComponent<CinemachineVirtualCamera>().Follow = Friends[index].transform;
                moveManager.GetComponent<MovePosition>().SetPosition(Friends[index]);
                isArrangement = true;

            }
        }
        else
        {
            if (Cost.UseCost(3))
            {
                switch (characterNumber[index])
                {
                    case 0:
                        Friends[index].GetComponent<BowSkill>().Skill();
                        break;
                    case 1:
                        Friends[index].GetComponent<KendoSkill>().Skill();
                        break;
                    case 2:
                        Friends[index].GetComponent<CleanSkill>().Skill();
                        break;
                    case 3:
                        Friends[index].GetComponent<SeaSkill>().Skill();
                        break;
                    case 4:
                        Friends[index].GetComponent<ScienceSkill>().Skill();
                        break;
                    case 5:
                        Debug.Log("boxer skill");
                        Friends[index].GetComponent<BoxerSkill>().Skill();
                        break;
                    case 6:
                        Friends[index].GetComponent<BandSkill>().Skill();
                        break;
                    case 7:
                        Friends[index].GetComponent<CookSkill>().Skill();
                        break;
                    case 8:
                        Friends[index].GetComponent<BookSkil>().Skill();
                        break;
                }
            }
            else effectSystem.GetComponent<EffectSystem>().Guide(SetedText, "�ڽ�Ʈ�� �����մϴ�.", 1);
        }
    }
}
