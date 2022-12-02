using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class CharacterArrangement : MonoBehaviour
{
    //배치인원
    [SerializeField] private int DeployPeople = 4;
    private int nowDeployPeople = 1;
    [SerializeField] private CinemachineClearShot clearShot;
    //배치 카드 배열
    [SerializeField] private GameObject[] CharacterCardList;
    //배치할 캐릭터 가져올 리스트
    [SerializeField] private List<GameObject> objects;
    //메인 카메라
    [SerializeField] private Camera mainCamera;
    //움직일 스크립트가 들어있는 오브젝트
    [SerializeField] private GameObject moveManager;
    //Null카메라를 가져올 변수
    [SerializeField] private Queue<GameObject> NullCameraList = new Queue<GameObject>();
    public bool isArrangement = false;
    void Start()
    {
        SetCard();
        for(int i=0; i< clearShot.ChildCameras.Length; i++)
        {
            if(clearShot.ChildCameras[i].name == "Null")
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
            Debug.Log("현재 배치 인원이 많습니다");
            DeployPeople = CharacterCardList.Length;
        }
        else if (DeployPeople != CharacterCardList.Length)
        {
            for (int i = DeployPeople; i < CharacterCardList.Length; i++)
            {
                CharacterCardList[i].SetActive(false);
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
        if (null == moveManager.GetComponent<MovePosition>().selected)
        {
            GameObject Char = Instantiate(objects[index], mainCamera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            GameObject C = NullCameraList.Dequeue();
            //Char.name = "캐릭터";
            C.SetActive(true);
            C.transform.position = Char.transform.position;
            C.name = Char.name;
            C.GetComponent<CinemachineVirtualCamera>().Follow = Char.transform;
            moveManager.GetComponent<MovePosition>().SetPosition(Char);
            isArrangement = true;

        }
    }
}
