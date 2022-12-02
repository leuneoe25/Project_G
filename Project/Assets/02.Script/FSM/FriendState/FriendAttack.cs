using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendAttack : State<Friend>
{
    float time;
    public override void Enter(Friend target)
    {
        if(target.detect.DetectiveObj == null)
        {
            target.ChangeState(FriendState.Idle);
        }
        if(target.detect.DetectiveObj.transform.position.x > target.transform.position.x)
        {
            target.transform.localScale = new Vector3(1, 1, 1);
            target.isRight = true;
        }
        else
        {
            target.transform.localScale = new Vector3(-1, 1, 1);
            target.isRight = false;
        }
        time = target.AttackSpeed - target.skillOn;
        if (target.FriendRoll == "RangeAttack")
        {
            target.attackFunc.Attack(target.ATK, target.transform);
        }
        else if (target.FriendRoll == "Melee")
        {
            target.attackFunc.Attack(target.ATK, target.detect.DetectiveObj);
        }
        else if (target.FriendRoll == "LongRange")
        {
            if(target.detect.DetectiveObj != null)
            {
                target.attackFunc.Attack(target.detect.gameObject.transform, target.detect.DetectiveObj.transform);
                Monster getmon = target.detect.DetectiveObj.GetComponent<Monster>();
                getmon.SetHP(target.ATK);
            }
        }
    }
    public override void Exit(Friend target)
    {
        base.Exit(target);
    }
    public override void Update(Friend target)
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            target.ChangeState(FriendState.Idle);
        }
    }
}
