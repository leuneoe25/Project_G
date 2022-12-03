using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSkill : MonoBehaviour
{
    [SerializeField] Friend friend;
    [SerializeField] GameObject clean;
    private float Spawntime = 0.1f;
    public float time = 4;
    public int cost = 3;
    float tempTime;
    bool SkillOn = false;
    public bool IsTest = false;

    public void Skill()
    {
        SkillOn = true;
        friend.ChangeState(FriendState.Run);
    }
    void Start()
    {
        tempTime = time;
    }
    void Update()
    {
        if(IsTest)
        if (Input.GetKeyDown(KeyCode.C))
        {
            Skill();
        }

        if (SkillOn)
        {
            time -= Time.deltaTime;
            Spawntime -= Time.deltaTime;
            if(Spawntime < 0)
            {
                Spawntime = 0.1f;
                Instantiate(clean, new Vector3(friend.transform.position.x, friend.transform.position.y - 3.5f, friend.transform.position.z), Quaternion.identity);
            }
        }
        if (time <= 0)
        {
            SkillOn = false;
            time = tempTime;
            Spawntime = 0.1f;
            friend.ChangeState(FriendState.Idle);

        }

    }
}
