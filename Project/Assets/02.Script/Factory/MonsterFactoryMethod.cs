using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Factory
{
    public abstract class MonsterFactoryMethod : MonsterFac
    {
        public override Monster CreateMonster(bool IsBoss)
        {
            Monster monster = null;
            if(!IsBoss)
            {
                //monster = new CreateMonster();
            }
            else
            {
                //monster = new CreateBoss();
            }

            return monster;
        }
    }
}

