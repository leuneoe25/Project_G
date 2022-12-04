using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mentos : MonoBehaviour
{
    // Start is called before the first frame update
    bool IsGorund;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            IsGorund = true;
        }
    }


    void Update()
    {
        if(!IsGorund)
        transform.Translate(Vector2.up * 10 * Time.deltaTime);
    }
}
