using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandSkill : MonoBehaviour
{
    [SerializeField] GameObject DetectALL;
    public int cost;
    public bool IsTest = false;

    void Start()
    {
        
    }

    public void Skill()
    {
        Instantiate(DetectALL, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(IsTest)
        if(Input.GetKeyDown(KeyCode.A))
        {
            Skill();
        }
    }
}
