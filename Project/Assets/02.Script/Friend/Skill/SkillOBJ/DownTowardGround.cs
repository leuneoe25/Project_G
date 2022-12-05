using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTowardGround : MonoBehaviour
{

    bool IsGround;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            IsGround = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!IsGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
    }
}
