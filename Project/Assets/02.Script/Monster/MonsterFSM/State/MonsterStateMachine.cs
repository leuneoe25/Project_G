using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine<T>
{
    private T _target;
    private MonsterState<T> _nowState;
    private MonsterState<T> _prevState;

    public void Init(T target, MonsterState<T> state)
    {
        _target = target;
        _nowState = state;
        _nowState.Enter(_target);
    }
    public void ChangeState(MonsterState<T> state)
    {
        _nowState.Exit(_target);
        _prevState = _nowState;
        _nowState = state;
        _nowState.Enter(_target);
    }
    public void ReverState()
    {
        if (_nowState == null && _prevState == null)
            return;
        _nowState.Exit(_target);
        _prevState.Enter(_target);
        //swap
        MonsterState<T> temp = _nowState;
        _nowState = _prevState;
        _prevState = temp;
    }
    public void Update()
    {
        if (_nowState == null)
            Debug.Log("null");
        _nowState?.Update(_target);
    }
}
