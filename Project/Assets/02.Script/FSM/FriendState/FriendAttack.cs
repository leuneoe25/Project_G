using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendAttack : State<Friend>
{//after
    float time;
    public override void Enter(Friend target)
    {
        Debug.Log("Iam Attack");
        time = target.AttackSpeed - target.skillOn;
        if (target.FriendRoll == "throw")
        {
            //target.attackFunc.Attack()
        }
        else if (target.FriendRoll == "Melee")
        {
            target.attackFunc.Attack(2/*target.damage)*/, target.detect.DetectiveObj);
        }
        else if (target.FriendRoll == "LongRange")
        {
            if(target.detect.DetectiveObj != null)
            {
                target.attackFunc.Attack(target.detect.gameObject.transform, target.detect.DetectiveObj.transform);
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
            Debug.Log("2222");
            target.ChangeState(FriendState.Idle);
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("1111");
            target.ChangeState(FriendState.Idle);
        }
    }
}
