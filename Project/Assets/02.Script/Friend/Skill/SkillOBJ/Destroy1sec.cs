using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy1sec : MonoBehaviour
{
    float time = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
