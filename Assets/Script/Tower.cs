using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public EnemyManager enemyManager;
    public TowerData towerData;

    private float attackTimer;

    public void DoUpdate()
    {

    }

    private void FixedUpdate()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Attack();
            ResetAttackTimer();
        }
    }

    private void Attack()
    {
        // attack
    }

    private void ResetAttackTimer()
    {
        attackTimer = 1 / towerData.attackSpeed;
    }
}
