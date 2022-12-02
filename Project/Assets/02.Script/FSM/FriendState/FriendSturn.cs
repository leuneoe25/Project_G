using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSturn : State<Friend>
{
    public override void Enter(Friend target)
    {
        base.Enter(target);
    }
    public override void Exit(Friend target)
    {
        base.Exit(target);
    }
    public override void Update(Friend target)
    {
        target.SturnTime -= Time.deltaTime;
        if(target.SturnTime < 0)
        {
            if (target.IsDead())
            {
                target.Killed();
            }
            else
            {
                target.ChangeState(FriendState.Idle);
            }
        }
    }
}
