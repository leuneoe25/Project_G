using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlow : MonoBehaviour
{
    float time = 9;
    float secondTime = 1f;
    bool isGround;
    int ColaSpeed = 1;
    void Start()
    {

    }
    float originalslow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            originalslow = monster.Speed / 2;
            monster.Speed -= originalslow;
        }
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
        }
        if(collision.CompareTag("Mentos"))
        {
            ColaSpeed++;
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
        if (!isGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (0.01f * ColaSpeed), transform.position.z);
        }
        if(isGround)
        time -= Time.deltaTime;
        if (time <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1000f, transform.position.z);
            secondTime -= Time.deltaTime;
            if (secondTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        if(isGround)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.04f, transform.localScale.y, transform.localScale.z);
        }
    }
}
