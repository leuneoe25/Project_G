using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncOfAttack : MonoBehaviour
{
    #region Arrow
    [SerializeField] GameObject Arrow;

    public void fireArrow(Transform pointA, Transform pointB, float time)
    {
        StartCoroutine(ArcherAttack(pointA, time));
    }


    IEnumerator ArcherAttack(Transform pointA, float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        Instantiate(Arrow, pointA.position, Quaternion.identity);

        yield return wait;
    }
    #endregion

    #region Kendo
    public void AttackWithSword(float Damage, float time, GameObject TargetObject)
    {
        Monster monster = TargetObject.GetComponent<Monster>();
        StartCoroutine(KendoAttack(Damage, time, monster));
    }

    IEnumerator KendoAttack(float Daamge, float time, Monster monster)
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        monster.SetHP(Daamge);

        yield return wait;
    }
    #endregion

    #region Boxer
    public void Punch(float Damage, float time, GameObject TargetObject)
    {
        Monster monster = TargetObject.GetComponent<Monster>();
        StartCoroutine(BoxerAttack(Damage, time, monster));
    }

    IEnumerator BoxerAttack(float Damage, float time, Monster monster)
    {
        WaitForSeconds wait = new WaitForSeconds(time);

        monster.SetHP(Damage);

        yield return wait;
    }
    #endregion
}
