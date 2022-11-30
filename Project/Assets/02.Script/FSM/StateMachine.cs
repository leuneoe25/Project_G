using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private T _target;
    private State<T> _nowState;
    private State<T> _prevState;

    public void Init(T target, State<T> state)
    {
        _target = target;
        _nowState = state;
    }
    public void ChangeState(State<T> state)
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
        State<T> temp = _nowState;
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
