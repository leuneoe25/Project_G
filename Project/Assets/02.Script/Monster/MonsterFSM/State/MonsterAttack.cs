using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterState<Monster>
{//after
    float time = 3;
    public override void Enter(Monster target)
    {
        target.animator.SetInteger("State", 1);
        time = 3;
        Friend friend = target.DetectPlayer.GetComponent<Friend>();
        Player player;
        if(friend == null)
        {
            player = target.DetectPlayer.GetComponent<Player>();
        }
        else
        {
            friend.SetHP(target.ATK);
        }
    }
    public override void Exit(Monster target)
    {
        base.Exit(target);
    }
    public override void Update(Monster target)
    {
        
        time -= Time.deltaTime;
        if(time <= 0)
        target.ChangeState(MonsterState.Run);
    }
}
