using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Run,
    Attack,
    Sturn
}

public class Monster : MonoBehaviour, IAttackAble, IGetDamagedAble
{
    [SerializeField] MonsterStat data;
    public GameObject targetPoint;
    public GameObject wave;
    //Friend friend = new Friend();
    public GameObject DetectPlayer;
    public float HP;
    public float Speed;
    public float SturnTime;
    public float ATK;
    public float ATKSpeed;
    public bool CollideCharacter = false;
    //Friend friend = new Friend();
    public Vector3 Target = new Vector3();

    #region FSM
    private MonsterState<Monster>[] states = new MonsterState<Monster>[]
    {
        new MonsterMove(), new MonsterAttack(), new MonsterSturn()
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
        if(collision.CompareTag("CleanSkill"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            DetectPlayer = collision.gameObject;
            CollideCharacter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("BoxerSkill"))
        {
            Body body = collision.GetComponent<Body>();

            if (body.GetBool())
            {
                Debug.Log("Left");
                transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            else
            {
                Debug.Log("right");
                transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CleanSkill"))
        {
            if(transform.position.x > targetPoint.transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y - 0.1f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y - 0.1f, transform.position.z);
            }
        }
        if (collision.CompareTag("Player"))
        {
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
                wave.GetComponent<MonsterWave>().Death();
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
