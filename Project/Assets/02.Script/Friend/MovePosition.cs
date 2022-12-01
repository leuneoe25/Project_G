using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class MovePosition : MonoBehaviour
{
    public GameObject selected;
    [SerializeField] private GameObject characterSelect;
    [SerializeField] private Camera mainCam;
    bool drow = false;

    public void ChangePosition()
    {
        selected = characterSelect.GetComponent<CharacterMoveSelect>().GetCharacter();
        selected.GetComponent<Friend>().animator.SetBool("IsMoving", true);
    }

    public void SetPosition(GameObject obj)
    {
        drow = true;
        selected = obj;
        selected.GetComponent<Friend>().animator.SetBool("IsMoving", true);
    }

    void Update()
    {
        if (null != selected)
        {
            Vector2 pos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            if (pos.y < -1.8f) pos.y = -3.5f;
            else pos.y = 1.7f;
            selected.transform.position = new Vector3(Mathf.Clamp(pos.x, -6f, 6f), pos.y, 0f);
            if (Input.GetMouseButtonDown(0) && !drow && !selected.GetComponent<Friend>().overlap)
            {
                selected.GetComponent<Friend>().animator.SetBool("IsMoving", false);
                selected = null;
            }
            else if (drow) { drow = false; }
        }
    }
}
