using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State<Player>
{
    public override void Enter(Player target)
    {
        base.Enter(target);
    }

    public override void Exit(Player target)
    {
        base.Exit(target);
    }
    public override void Update(Player target)
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            target.ChangeState(PlayerState.Run);
        }
    }
}
