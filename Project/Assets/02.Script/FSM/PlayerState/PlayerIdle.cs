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
        if (Input.GetKeyDown(KeyCode.A))
        {
            target.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            target.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //target.animator.SetInteger("State", (int)PlayerState.Move);
            target.ChangeState(PlayerState.Move);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //target.animator.SetInteger("State", (int)PlayerState.Move);
            target.ChangeState(PlayerState.Move);
        }
    }
}
