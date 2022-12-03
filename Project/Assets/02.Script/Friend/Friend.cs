using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FriendState
{
    Idle,
    Run,
    Attack,
    Sturn
}

public class Friend : MonoBehaviour, IAttackAble, IGetDamagedAble
{
    [SerializeField] public DetectInRange detect;
    [SerializeField] FriendStat Data;

    #region public
    public float AttackSpeed;
    public Rigidbody2D rigid;
    public Animator animator;
    public FuncOfAttack attackFunc;
    public string FriendRoll;
    public int skillOn = 0;
    #endregion

    public float HP;
    public float ATK;
    public float MoveSpeed;
    public float SturnTime;
    public int atk { get; set; }

    public bool overlap = false;

    private State<Friend>[] states = new State<Friend>[]
    {
       new FriendIdle(), new FriendRun(), new FriendAttack(), new FriendSturn()
    };
    private StateMachine<Friend> machine = new StateMachine<Friend>();
    
    public bool isRight;

    public void Killed()
    {
        Destroy(gameObject);
    }
    public bool IsDead()
    {
        if(HP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void IGetDamagedAble.GetDamaged(int value)
    {

    }

    void SetStat()
    {
        HP = Data.hp;
        ATK = Data.atk;
        MoveSpeed = Data.moveSpeed;
        AttackSpeed = Data.atkSpeed;
    }

    public void SetHP(float Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            SturnTime = 5;
            ChangeState(FriendState.Sturn);
            Debug.Log("Character is die");
        }
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        machine.Init(this.GetComponent<Friend>(), states[(Int32)FriendState.Idle]);
        attackFunc = gameObject.GetComponent<FuncOfAttack>();
        SetStat();
    }
    public void ChangeState(FriendState state)
    {
        animator.SetInteger("State", (Int32)state);
        machine.ChangeState(states[(Int32)state]);
    }

    void Update()
    {
        if (AttackSpeed - skillOn <= 0)
        {
            AttackSpeed = skillOn + 0.1f;
        }
        machine.Update();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer)
        {
            float x = collision.transform.position.x - transform.position.x;
            float y = collision.transform.position.y - transform.position.y;
            if (Mathf.Sqrt(x * x + y * y) < 1.1f)
                overlap = true;
            else
                overlap = false;
        }
    }
}