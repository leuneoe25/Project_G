using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterMoveSelect : MonoBehaviour
{
    private GameObject SelectCharacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private GameObject CharacterSelectUI;
    RaycastHit2D raycast;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)/* && !CharacterSelectUI.activeSelf*/)
        {
            raycast = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.down, 0.1f,LayerMask.GetMask("Character"));
            if(raycast.collider != null)
            {
                if(SelectCharacter == null)
                {
                    Debug.Log(raycast.collider.name);
                    SelectCharacter = raycast.collider.gameObject;
                    ZoomIn(SelectCharacter);
                }
                else
                {
                    ZoomOut(SelectCharacter);
                    SelectCharacter = raycast.collider.gameObject;
                    ZoomIn(SelectCharacter);
                }
            }
            else
            {
                Debug.Log("null");
                if (SelectCharacter != null)
                {
                    ZoomOut(SelectCharacter);
                    SelectCharacter = null;
                }
            }

        }
    }
    private void ZoomIn(GameObject ZoomCharacter)
    {
        int index = FindCharacter(ZoomCharacter);
        clearShot.ChildCameras[index].Priority = 11;
        CharacterSelectUI.SetActive(true);
    }
    private void ZoomOut(GameObject ZoomCharacter)
    {
        int index = FindCharacter(ZoomCharacter);
        clearShot.ChildCameras[index].Priority = 9;
        CharacterSelectUI.SetActive(false);
    }
    private int FindCharacter(GameObject ZoomCharacter)
    {
        int index;
        for(index = 1; index < clearShot.ChildCameras.Length;index++)
        {
            if(clearShot.ChildCameras[index].name == ZoomCharacter.name)
            {
                return index;
            }
        }
        return 0;
    }
}
