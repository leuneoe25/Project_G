using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonsterState<Monster>
{//after
    Vector3 TargetPos;
    public override void Enter(Monster target)
    {
        Debug.Log("Run");
        target.animator.SetInteger("State", (int)MonsterState.Run);
        TargetPos = new Vector3(target.Target.x - target.transform.position.x, 0f, 0f);
    }
    public override void Exit(Monster target)
    {
        base.Exit(target);
    }
    public override void Update(Monster target)
    {
        if(Mathf.Abs(target.Target.x - target.transform.position.x) >= 1f)
        target.transform.Translate(TargetPos * target.Speed * Time.deltaTime, Space.World);
        if(target.CollideCharacter)
        {
            target.ChangeState(MonsterState.Attack);
        }
    }
}
