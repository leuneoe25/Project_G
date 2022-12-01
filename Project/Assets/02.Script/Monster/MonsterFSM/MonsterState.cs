using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState<T>
{
    public virtual void Enter(T target) { }
    public virtual void Exit(T target) { }
    public virtual void Update(T target) { }
}
