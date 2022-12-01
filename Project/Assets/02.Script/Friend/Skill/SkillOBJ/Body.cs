using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private float time = 2;
    bool IsLeft;
    public void left()
    {
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
        IsLeft = true;
    }
    public void Right()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        IsLeft = false;
    }
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            monster.SetHP(monster.HP / 2);
        }
        
    }

    void Update()
    {
        if(IsLeft)
        {
            transform.Translate(Vector3.right * 15 * Time.deltaTime);
            time -= Time.deltaTime;
            if(time < 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.left * 15 * Time.deltaTime);
            time -= Time.deltaTime;
            if (time < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
