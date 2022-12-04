using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mentos : MonoBehaviour
{
    // Start is called before the first frame update
    bool IsGorund;
    float time = 4;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            IsGorund = true;
        }
        if(collision.CompareTag("Cola"))
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if(!IsGorund)
        {
            transform.Translate(Vector2.up * 10 * Time.deltaTime);
        }
        if (IsGorund)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
