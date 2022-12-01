using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterArrangement : MonoBehaviour
{
    //배치인원
    [SerializeField] private int DeployPeople = 4;
    [SerializeField] private GameObject[] CharacterCardList;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private Camera mainCamera;
    private GameObject CreateCharacterObject;
    void Start()
    {
        SetCard();
    }

    // Update is called once per frame
    void Update()
    {
        if(CreateCharacterObject!=null)
        {
            
            CreateCharacterObject.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            CreateCharacterObject.transform.position = new Vector3(CreateCharacterObject.transform.position.x, CreateCharacterObject.transform.position.y, 0);
        }
    }
    private void SetCard()
    {
        if (DeployPeople > CharacterCardList.Length)
        {
            Debug.Log("현재 배치 인원이 많습니다");
            DeployPeople = CharacterCardList.Length;
        }
        else if(DeployPeople != CharacterCardList.Length)
        {
            for(int i = DeployPeople; i< CharacterCardList.Length;i++)
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
        CreateCharacterObject = Instantiate(objects[0], mainCamera.ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);
    }
}
