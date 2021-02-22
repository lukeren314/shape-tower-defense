using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/TowerData", order = 2)]
public class TowerData : ScriptableObject
{
    public float attackDamage;
    public float attackSpeed;
    public float attackRange;

}
