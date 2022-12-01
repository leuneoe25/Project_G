using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    private bool spawnLeft = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spawnLeft) Instantiate(enemy, left.position,Quaternion.Euler(0,0,0));
            else Instantiate(enemy, right.position, Quaternion.Euler(0, 180f, 0));
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            spawnLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            spawnLeft = false;
        }
    }
}
