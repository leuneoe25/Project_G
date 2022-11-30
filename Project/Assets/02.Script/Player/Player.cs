using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Run
}

public class Player : MonoBehaviour
{
    private State<Player>[] states = new State<Player>[]
   {
        new PlayerIdle(),new PlayerRun()
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            rigid.velocity = Vector2.zero;
        }
        if (Input.GetKeyUp(KeyCode.W) && Physics2D.Raycast(transform.position, Vector2.down, 0.8f, (1 << 7)) == true)
        {
            Physics2D.IgnoreLayerCollision(6, 8, true);
        }
        else if (Input.GetKeyUp(KeyCode.W) && Physics2D.Raycast(transform.position, Vector2.down, 0.8f, (1 << 8)) == true)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }
    }

    void Update()
    {
        machine.Update();
    }
}
