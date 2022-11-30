using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FriendState
{
    Idle,
    Run,
    Attack
}

public class Friend : MonoBehaviour, IAttackAble, IGetDamagedAble
{
    [SerializeField] public DetectInRange detect;

    public float AttackSpeed = 2f;
    public Rigidbody2D rigid;
    public Animator animator;
    public FuncOfAttack attackFunc;
    public string FriendRoll;
    public int skillOn = 0;
    public int atk { get; set; }

    private State<Friend>[] states = new State<Friend>[]
    {
       new FriendIdle(), new FriendRun(), new FriendAttack()
    };
    private StateMachine<Friend> machine = new StateMachine<Friend>();

    void IGetDamagedAble.GetDamaged(int value)
    {

    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        machine.Init(this.GetComponent<Friend>(), states[(Int32)FriendState.Idle]);
        attackFunc = gameObject.GetComponent<FuncOfAttack>();
    }
    public void ChangeState(FriendState state)
    {
        animator.SetInteger("State", (Int32)state);
        machine.ChangeState(states[(Int32)state]);
    }

    void Update()
    {
        machine.Update();
    }
}
