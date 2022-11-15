using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class MonsterFac : MonoBehaviour
    {
        public Monster OrderMonster(bool IsBoss)
        {
            Monster monster = CreateMonster(IsBoss);
            //몬스터 스텟 및 여러 상태 결정
            monster.SetHP();
            monster.SetATKSYS();
            monster.SetMoveSys();

            return monster;
        }

        public abstract Monster CreateMonster(bool IsBoss);
    }
}
