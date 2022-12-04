using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceSkill : MonoBehaviour
{
    [SerializeField] GameObject MENTOS;
    [SerializeField] GameObject Cola;

    public int cost;
    public bool IsTest;
    void Start()
    {
        
    }

    public void Skill()
    {
        for(int i = 0; i < 4; ++i)
        {
            Vector3 pointB = new Vector3(gameObject.transform.position.x + Random.Range(-8.1f, 8.1f), gameObject.transform.position.y, gameObject.transform.position.z);
            Vector3 dir = pointB - transform.position;
            GameObject NewArrow;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            NewArrow = Instantiate(MENTOS, transform.position, Quaternion.identity);
            NewArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(IsTest)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Skill();
            }
        }
    }
}
