using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerSkill : MonoBehaviour
{
    [SerializeField] Friend boxer;
    [SerializeField] GameObject FlyingBody;
    public float cost;
    void Skill()
    {
        if (boxer.detect.DetectiveObj != null)
        {
            //�ڽ�Ʈ �Ҹ�
            Vector3 position = boxer.detect.DetectiveObj.transform.position;
            Destroy(boxer.detect.DetectiveObj.gameObject);
            GameObject monster = Instantiate(FlyingBody, position, Quaternion.identity);
            Body body = monster.GetComponent<Body>();
            if (boxer.transform.position.x > position.x)
            {
                body.Right();
            }
            else
            {
                body.left();
            }
        }
        else
        {
            Debug.Log("There is No Target!");
        }
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Skill();
        }
    }
}
