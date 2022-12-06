using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendoSkill : MonoBehaviour
{
    [SerializeField] GameObject kenki;
    [SerializeField] Friend kendo;
    public int cost;
    public bool IsTest = false;

    public void Skill()
    {
        if(kendo.detect.DetectiveObj != null)
        {
            Vector3 position = kendo.detect.DetectiveObj.transform.position;
            Vector3 KenkiPos = new Vector3(kendo.transform.position.x, kendo.transform.position.y - 0.5f, kendo.transform.position.z);
            GameObject Obj = Instantiate(kenki, KenkiPos, Quaternion.identity);
            Kenki Ki = Obj.GetComponent<Kenki>();
            Obj.name = gameObject.name;
            if (kendo.transform.position.x > position.x)
            {
                Ki.left();
            }
            else if (kendo.transform.position.x < position.x)
            {
                Ki.Right();
            }
        }
        else
        {
            GameObject.Find("CostManager").GetComponent<CostControl>().GSCost(3);
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTest)
        if(Input.GetKeyDown(KeyCode.K))
        {
            Skill();
        }
    }
}
