using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    // tracks the spawning of an enemy wave
    public EnemyWave enemyWave;
    private EnemyManager enemyManager;
    private int currentEnemy;

    private float spawnTimer;

    public EnemySpawner(EnemyWave enemyWave, EnemyManager enemyManager) 
    {
        this.enemyWave = enemyWave;
        this.enemyManager = enemyManager;
        currentEnemy = 0;
    }

    public void DoFixedUpdate() 
    {
        while (spawnTimer >= enemyWave.spacing)
        {
            if (IsFinished())
            {
                break;
            }
            SpawnEnemy();
            ++currentEnemy;
            ResetSpawnTimer();
        }
        spawnTimer += Time.deltaTime;
    }

    public bool IsFinished()
    {
        return currentEnemy == enemyWave.count - 1;
    }

    private void SpawnEnemy()
    {
        enemyManager.SpawnEnemy(enemyWave.enemyType);
    }

    private void ResetSpawnTimer()
    {
        spawnTimer = 0;
    }
}
