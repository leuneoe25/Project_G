using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : State<Player>
{
    public override void Enter(Player target)
    {
        target.animator.SetInteger("State", (int)PlayerState.Run);
    }
    public override void Exit(Player target)
    {
        target.animator.SetInteger("State", (int)PlayerState.Idle);
    }
    public override void Update(Player target)
    {
        if (Input.GetKey(KeyCode.A))
        {
            target.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            target.gameObject.transform.position += Vector3.left * target.moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            target.gameObject.transform.localScale = new Vector3(1, 1, 1);
            target.gameObject.transform.position += Vector3.right * target.moveSpeed * Time.deltaTime;
        }
        else
        {
            target.ChangeState(PlayerState.Idle);
        }
    }
}