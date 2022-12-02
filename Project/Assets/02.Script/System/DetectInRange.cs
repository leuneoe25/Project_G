using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInRange : MonoBehaviour
{
    public bool IsInRange;
    public GameObject DetectiveObj;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            DetectiveObj = collision.gameObject;
            IsInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            DetectiveObj = null;
            IsInRange = false;
        }
    }
}
