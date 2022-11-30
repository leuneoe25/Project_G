using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] MonsterStat data;
        float HP;
        float Speed;
        float ATK;
        float ATKSpeed;

        public void SetHP(float _hp)
        {
            HP -= _hp;
            if(HP <= 0)
            {
                Destroy(gameObject);
            }
        }
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

        void Start()
        {

        }
        void Update()
        {

        }
    }
}