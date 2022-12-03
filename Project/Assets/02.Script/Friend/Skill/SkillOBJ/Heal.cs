using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    float time = 2;
    [SerializeField] GameObject RedP;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Friend friend = collision.GetComponent<Friend>();
            if(friend == null)
            {
                Player player = collision.GetComponent<Player>();
                Instantiate(RedP, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);
                player.SetHP(-30f);
            }
            else
            {
                friend.SetHP(-1 * (friend.Data.hp / 3));
                Instantiate(RedP, new Vector3(friend.transform.position.x, friend.transform.position.y + 1, friend.transform.position.z), Quaternion.identity);
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
        if(time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
