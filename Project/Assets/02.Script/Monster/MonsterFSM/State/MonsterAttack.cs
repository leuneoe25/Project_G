using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterState<Monster>
{//after
    float time = 3;
    public override void Enter(Monster target)
    {
        Friend friend;
        Player player;
        if (!target.collidedDoor)
        {

            friend = target.DetectPlayer.GetComponent<Friend>();
            if (friend == null)
            {
                player = target.DetectPlayer.GetComponent<Player>();
            }
            else
            {
                friend.SetHP(target.ATK);
            }
        }
        target.animator.SetInteger("State", 1);
        time = 3;
    }
    public override void Exit(Monster target)
    {
        base.Exit(target);
    }
    public override void Update(Monster target)
    {
        
        time -= Time.deltaTime;
        if(time <= 0)
        {
            target.ChangeState(MonsterState.Run);
            target.CollideCharacter = false;
            DoorAttacked door = target.targetPoint.GetComponent<DoorAttacked>();
            door.SetHp(target.ATK);
        }
    }
}
