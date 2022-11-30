using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

enum pos
{
    DL, DR, UL, UR
}

public class MovePosition : MonoBehaviour
{
    private GameObject selected;
    [SerializeField] private GameObject characterSelect;
    [SerializeField] private Camera mainCam;

    public void ChangePosition()
    {
        selected = characterSelect.GetComponent<CharacterMoveSelect>().GetCharacter();
    }

    void Update()
    {
        if (null != selected)
        {
            Vector2 pos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            if (pos.y < -1.8f) pos.y = -3.5f;
            else pos.y = 1.7f;
            selected.transform.position = new Vector3(Mathf.Clamp(pos.x, -6f, 6f), pos.y, 0f);
            if (Input.GetMouseButtonDown(0))
            {
                selected = null;
            }
        }
    }
}