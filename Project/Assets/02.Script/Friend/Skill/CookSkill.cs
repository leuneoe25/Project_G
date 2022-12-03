using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSkill : MonoBehaviour
{
    [SerializeField] GameObject Heal;
    public int cost;
    public bool IsTest = false;
    void Start()
    {
        
    }

    public void Skill()
    {
        Instantiate(Heal, gameObject.transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(IsTest)
        if(Input.GetKeyDown(KeyCode.O))
        {
            Skill();
        }
    }
}
