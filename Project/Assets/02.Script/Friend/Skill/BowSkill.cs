using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSkill : MonoBehaviour
{
    [SerializeField] Friend friend;
    public float time = 5;
    float tempTime;
    float tempSpeed;
    bool SkillOn = false;

    void Skill()
    {
        SkillOn = true;
        friend.AttackSpeed = friend.skillOn + 0.1f;
    }
    void Start()
    {
        tempSpeed = friend.AttackSpeed;
        tempTime = time;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Skill();
        }

        if(SkillOn)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0)
        {
            SkillOn = false;
            time = tempTime;
            friend.AttackSpeed = tempSpeed;
        }
        
    }
}
