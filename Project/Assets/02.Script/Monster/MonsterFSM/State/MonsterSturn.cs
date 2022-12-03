using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSturn : MonsterState<Monster>
{
    public override void Enter(Monster target)
    {
        base.Enter(target);
    }
    public override void Exit(Monster target)
    {
        base.Exit(target);
    }
    public override void Update(Monster target)
    {
        target.SturnTime -= Time.deltaTime;
        if (target.SturnTime <= 0)
        {
            target.SturnTime = 0;
            target.ChangeState(MonsterState.Run);
        }
    }
}
