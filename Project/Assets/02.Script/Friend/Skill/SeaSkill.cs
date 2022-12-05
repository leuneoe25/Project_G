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
        if (Sea.detect.DetectiveObj != null)
        {
            Vector3 position = Sea.detect.DetectiveObj.transform.position;
            GameObject Wave = Instantiate(SeaWater, transform.position, Quaternion.identity);
            Body body = Wave.GetComponent<Body>();

            if (Sea.transform.position.x > position.x)
            {
                body.left();
            }
            else if(Sea.transform.position.x < position.x)
            {
                body.Right();
            }
        }
        else
        {

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