using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncOfAttack : MonoBehaviour
{

    #region Arrow
    [SerializeField] GameObject Arrow;

    public void Attack(Transform pointA, Transform pointB)
    {
        StartCoroutine(ArcherAttack(pointA, pointB));
    }


    IEnumerator ArcherAttack(Transform pointA, Transform pointB)
    {
        Vector3 dir = pointB.position - pointA.position;
        GameObject NewArrow;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        NewArrow = Instantiate(Arrow, pointA.position, Quaternion.identity);
        NewArrow.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        yield return null;
    }
    #endregion

    #region Kendo
    public void Attack(float Damage, GameObject TargetObject)
    {
        Monster monster = TargetObject.GetComponent<Monster>();
        StartCoroutine(MeleeWeaponAttack(Damage, monster));
    }

    IEnumerator MeleeWeaponAttack(float Daamge, Monster monster)
    {
        monster.SetHP(Daamge);

        yield return null;
    }
    #endregion

    
}