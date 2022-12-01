using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendIdle:State<Friend>
{//after
    public override void Enter(Friend target)
    {
        Debug.Log("iam idle");
    }
    public override void Exit(Friend target)
    {
        base.Exit(target);
    }
    public override void Update(Friend target)
    {
        if(target.detect.IsInRange)
        {
            Debug.Log("gotoAttack");
            target.ChangeState(FriendState.Attack);
        }
    }
}
