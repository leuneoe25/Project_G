using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class Monster : MonoBehaviour
    {


        //[SerializeField] MonsterData data;
        float HP;
        float Speed;
        float ATK;
        float ATKSpeed;

        public void SetHP()
        {
            //HP = data.hp;
        }

        public void SetATKSYS()
        {
            //ATK = data.ATK;
            //ATKSpeed = data.ATKSpeed;
        }

        public void SetMoveSys()
        {
            //Speed = data.Speed;
        }

        void Start()
        {

        }
        void Update()
        {

        }
    }
}