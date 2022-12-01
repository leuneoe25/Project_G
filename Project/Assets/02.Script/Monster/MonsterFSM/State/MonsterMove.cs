using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonsterState<Monster>
{//after
    public override void Enter(Monster target)
    {
        Debug.Log("Run");
    }
    public override void Exit(Monster target)
    {
        base.Exit(target);
    }
    public override void Update(Monster target)
    {
        if(target.transform.position.x != target.Target.x)
        target.transform.Translate((target.Target - target.transform.position) * target.Speed * Time.deltaTime, Space.World);
        if(target.CollideCharacter)
        {
            target.ChangeState(MonsterState.Attack);
        }
    }
}
