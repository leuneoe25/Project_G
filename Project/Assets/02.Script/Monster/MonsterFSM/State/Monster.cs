using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Run,
    Attack
}

public class Monster : MonoBehaviour, IAttackAble, IGetDamagedAble
{
    [SerializeField] MonsterStat data;
    [SerializeField] GameObject targetPoint;
    //Friend friend = new Friend();
    public float HP;
    public float Speed;
    public float ATK;
    public float ATKSpeed;
    public bool CollideCharacter = false;
    //Friend friend = new Friend();
    public Vector3 Target = new Vector3();

    #region FSM
    private MonsterState<Monster>[] states = new MonsterState<Monster>[]
    {
        new MonsterMove(), new MonsterAttack()
    };
    private MonsterStateMachine<Monster> machine = new MonsterStateMachine<Monster>();

    public Rigidbody2D rigid;
    public Animator animator;

    public void ChangeState(MonsterState state)
    {
        machine.ChangeState(states[(Int32)state]);
    }
    #endregion

    #region Collide Event

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collide");
            CollideCharacter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Uncollide");
            CollideCharacter = false;
        }
    }
    #endregion

    #region Stat
    public float GetHP()
    {
        return HP;
    }
    public void SetStat()
    {
        ATK = data.atk;
        ATKSpeed = data.atkSpeed;
        Speed = data.moveSpeed;
        HP = data.hp;
    }
    #endregion

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        machine.Init(this.GetComponent<Monster>(), states[(Int32)MonsterState.Run]);
        Target = targetPoint.transform.position;
        SetStat();
    }

    public int atk { get; set; }

    public void SetHP(float _hp)
    {
        HP -= _hp;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GetDamaged(int value)
    {

    }

    void Update()
    {
        machine.Update();
    }
}