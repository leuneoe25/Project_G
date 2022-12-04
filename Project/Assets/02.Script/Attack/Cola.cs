using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola : MonoBehaviour
{
    [SerializeField] GameObject Slow;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") || collision.CompareTag("Poundation"))
        {
            Instantiate(Slow, transform.position, Quaternion.identity);
        }
    }
    float time = 3;
    void Update()
    {
        time -= Time.deltaTime;
        transform.Translate(Vector2.up * 40 * Time.deltaTime);
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
