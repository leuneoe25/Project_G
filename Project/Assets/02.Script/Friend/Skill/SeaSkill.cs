using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSkill : MonoBehaviour
{
    [SerializeField] GameObject SeaWater;
    [SerializeField] Friend Sea;
    public bool IsTest = false;
    public int cost;

    public void Skill()
    {
        //코스트 소모
        GameObject Wave = Instantiate(SeaWater, transform.position, Quaternion.identity);
        Body body = Wave.GetComponent<Body>();
        if (Sea.isRight)
        {
            body.Right();
        }
        else
        {
            body.left();
        }
    }

    private void Update()
    {
        if(IsTest)
        if (Input.GetKeyDown(KeyCode.S))
        {
            Skill();
        }
    }
}