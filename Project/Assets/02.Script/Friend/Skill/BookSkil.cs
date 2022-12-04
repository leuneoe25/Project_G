using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSkil : MonoBehaviour
{
    [SerializeField] GameObject book;
    public int cost;
    public bool IsTest = false;

    public void Skill()
    {
        Instantiate(book, transform.position, Quaternion.identity);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTest)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Skill();
            }
        }
    }
}
