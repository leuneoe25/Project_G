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
            //���� ���� �� ���� ���� ����
            monster.SetHP();
            monster.SetATKSYS();
            monster.SetMoveSys();

            return monster;
        }

        public abstract Monster CreateMonster(bool IsBoss);
    }
}
