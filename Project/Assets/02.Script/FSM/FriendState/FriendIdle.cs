using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendIdle:State<Friend>
{//after
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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            target.ChangeState(FriendState.Run);
        }
    }
}
