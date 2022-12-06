using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonsterState<Monster>
{//after
    Vector3 TargetPos;
    public override void Enter(Monster target)
    {
        target.animator.SetInteger("State", (int)MonsterState.Run);
        TargetPos = new Vector3(target.Target.x - target.transform.position.x, 0f, 0f);
    }
    public override void Exit(Monster target)
    {
        base.Exit(target);
    }
    public override void Update(Monster target)
    {
        if (target.SturnTime > 0)
        {
            target.ChangeState(MonsterState.Sturn);
        }
        if (Mathf.Abs(target.Target.x - target.transform.position.x) >= 1f)
        target.transform.Translate(TargetPos * target.Speed * Time.deltaTime, Space.World);
        if(target.CollideCharacter)
        {
            Player player;
            Friend friend = target.DetectPlayer.GetComponent<Friend>();
            if (friend == null)
            {
                player = target.DetectPlayer.GetComponent<Player>();
                //player.SetHP();
            }
            else if (!friend.IsDead())
            {
                target.ChangeState(MonsterState.Attack);
            }
        }
        else if(target.collidedDoor)
        {
            target.MonsterAttack++;
            target.ChangeState(MonsterState.Attack);
        }
    }
}
