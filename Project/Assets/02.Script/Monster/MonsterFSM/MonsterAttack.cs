using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterState<Monster>
{//after
    float time = 3;
    public override void Enter(Monster target)
    {
        Debug.Log("Attack!");
        time = 3;
        //target.friend.SetHP(ATK);
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
