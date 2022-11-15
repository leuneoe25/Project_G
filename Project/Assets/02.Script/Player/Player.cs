using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Move,
    Jump
}

public class Player : MonoBehaviour
{
    private State<Player>[] states = new State<Player>[]
   {
        new PlayerIdle(),new PlayerRun(),new PlayerJump()
   };
    private StateMachine<Player> machine = new StateMachine<Player>();

    //public EnityData data;
    public Rigidbody2D rigid;
    public Animator animator;


    public float moveSpeed = 3f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        machine.Init(this.GetComponent<Player>(), states[(Int32)PlayerState.Idle]);
    }
    public void ChangeState(PlayerState state)
    {
        animator.SetInteger("State", (Int32)state);
        machine.ChangeState(states[(Int32)state]);
    }

    // Update is called once per frame
    void Update()
    {
        machine.Update();
    }
}
