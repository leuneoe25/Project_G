using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    float time = 3;
    float secondTime = 1f;
    bool isGround;
    void Start()
    {
        
    }
    float originalslow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            originalslow = monster.Speed / 3;
            monster.Speed -= originalslow;
        }
        if(collision.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            monster.Speed += originalslow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
        }
        time -= Time.deltaTime;
        if(time <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1000f, transform.position.z);
            secondTime -= Time.deltaTime;
            if(secondTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
