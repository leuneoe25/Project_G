using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] FriendStat stat;
    bool isOnGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if(collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            monster.SetHP(stat.atk);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(!isOnGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.098f, transform.position.z);
        }
    }
}
