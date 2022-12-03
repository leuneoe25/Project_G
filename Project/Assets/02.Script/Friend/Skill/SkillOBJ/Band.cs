using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Band : MonoBehaviour
{
    float time = 4;
    float time2 = 1;
    private bool SkillEnded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Friend friend = collision.GetComponent<Friend>();
            if (friend == null)
            {

            }
            else
            {
                friend.skillOn += 0.2f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Friend friend = collision.GetComponent<Friend>();
            if (friend == null)
            {

            }
            else
            {
                friend.skillOn -= 0.2f;
            }
        }
    }

    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
            time2 -= Time.deltaTime;
            if(time2 <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
