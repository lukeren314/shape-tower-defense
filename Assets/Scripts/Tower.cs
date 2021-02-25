using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TargetType
    {
        FIRST,
        HEALTHIEST
    }
    public TowerData towerData;
    public EnemyManager enemyManager;
    public ProjectileManager projectileManager;

    public ProjectileData baseProjectile;

    public TargetType targetType;
    private float attackTimer;
    private Enemy targettedEnemy;

    public void OnCreate(TowerData towerData, EnemyManager enemyManager, ProjectileManager projectileManager, Vector2 position)
    {
        this.towerData = towerData;
        this.enemyManager = enemyManager;
        this.projectileManager = projectileManager;
        
        transform.position = position;
        ResetAttackTimer();
        targetType = TargetType.FIRST;
        targettedEnemy = null;
    }

    public void DoFixedUpdate()
    {
        // if the attack speed is <= 0, we don't want to attack at all
        // it might lead to unhealthy math (division by zero! negative attack timers!)
        if (towerData.attackSpeed > 0)
        {
            while (attackTimer <= 0)
            {
                Attack();
                ResetAttackTimer();
            }
            attackTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        // find enemies in range, pick the right target, and FIRE!
        List<Enemy> enemiesInRange = GetEnemiesInRange();
        if (enemiesInRange.Count > 0)
        {
            Enemy targetEnemy = PickTarget(enemiesInRange);
            targettedEnemy = targetEnemy;
            AttackTarget(targetEnemy);
        }
    }

    private List<Enemy> GetEnemiesInRange()
    {
        List<Enemy> enemies = enemyManager.enemies;
        List<Enemy> enemiesInRange = new List<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            // if the distance from our tower to the enemy is within range
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance <= towerData.attackRange)
            {
                enemiesInRange.Add(enemy);
            }
        }
        return enemiesInRange;
    }

    private Enemy PickTarget(List<Enemy> enemies)
    {
        switch (targetType)
        {
            case TargetType.FIRST:
                return PickTargetFirst(enemies);
            case TargetType.HEALTHIEST:
                return PickTargetHealthiest(enemies);
        }
        return PickTargetFirst(enemies);
    }

    private Enemy PickTargetFirst(List<Enemy> enemies)
    {
        Enemy firstEnemy = enemies[0];
        float firstDistance = enemies[0].totalDistance;
        for (int i = 1; i < enemies.Count; ++i)
        {
            if (enemies[i].totalDistance > firstDistance)
            {
                firstDistance = enemies[i].totalDistance;
                firstEnemy = enemies[i];
            }
        }
        return firstEnemy;
    }

    private Enemy PickTargetHealthiest(List<Enemy> enemies)
    {
        Enemy healthiestEnemy = enemies[0];
        float healthiestValue = enemies[0].currentHealth;
        for (int i = 1; i < enemies.Count; ++i)
        {
            if (enemies[i].currentHealth > healthiestValue)
            {
                healthiestValue = enemies[i].currentHealth;
                healthiestEnemy = enemies[i];
            }
        }
        return healthiestEnemy;
    }

    private void AttackTarget(Enemy enemy)
    {
        // enemy.TakeDamage(towerData.attackDamage);
        projectileManager.SpawnProjectile(baseProjectile, this, enemy);
    }

    private void ResetAttackTimer()
    {
        attackTimer = 1 / towerData.attackSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
        if (targettedEnemy != null)
        {
            Gizmos.DrawWireSphere(targettedEnemy.transform.position, 1);
        }
    }
}
