using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/FriendStat", order = 1)]
public class FriendStat : ScriptableObject
{
    [SerializeField] private float _hp;
    [SerializeField] private float _apk;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _atkSpeed;

    public float hp { get { return _hp; } }
    public float atk { get { return _apk; } }
    public float atkSpeed { get { return _atkSpeed; } }
    public float moveSpeed { get { return _moveSpeed; } }
}
