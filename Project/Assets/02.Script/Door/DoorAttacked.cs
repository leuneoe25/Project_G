using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAttacked : MonoBehaviour
{
    public float HP = 500;

    void Start()
    {
        HP *= GoodsSystem.Instance.GSetCouncilLv();
    }

    public void SetHp(float value)
    {
        HP -= value;
        if(HP < 0)
        {
            Debug.Log("DoorIsDestroied!");
        }
    }

    void Update()
    {
        
    }
}
