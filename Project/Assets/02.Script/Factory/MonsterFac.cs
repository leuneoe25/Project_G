using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class MonsterFac : MonoBehaviour
    {
        public Monster OrderMonster(bool IsBoss)
        {
            Monster monster = CreateMonster(IsBoss);
            monster.SetStat();
            return monster;
        }

        public abstract Monster CreateMonster(bool IsBoss);
    }
}
