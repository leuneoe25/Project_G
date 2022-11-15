using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : State<Player>
{
    public override void Enter(Player target)
    {
        base.Enter(target);
    }
    public override void Exit(Player target)
    {
        target.animator.SetInteger("State", (int)PlayerState.Idle);
    }
    public override void Update(Player target)
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    target.ChangeState(PlayerState.Jump);

        //}

        if (Input.GetKey(KeyCode.A))
        {
            target.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            target.gameObject.transform.position += Vector3.left * target.moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            target.gameObject.transform.localScale = new Vector3(1, 1, 1);
            target.gameObject.transform.position += Vector3.right * target.moveSpeed * Time.deltaTime;
        }


        if (!Input.anyKey)
        {
            target.ChangeState(PlayerState.Idle);
        }
    }
}
