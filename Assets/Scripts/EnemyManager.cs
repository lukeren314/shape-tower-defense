using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : BaseManager
{
    // this is the enemy manager class
    // it manages all of the enemies
    public List<Enemy> enemies;
    public List<EnemySpawner> enemySpawners;
    public Enemy enemyPrefab;
    public PathData pathData;
    public RoundManager roundManager;

    private EnemyRoundData currentRound;
    private int currentEnemyEvent;
    private bool roundOver;

    private float eventTimer;

    public override void DoStart()
    {
        // set up these lists
        enemies = new List<Enemy>();
        enemySpawners = new List<EnemySpawner>();

        // initialize the first round
        ResetRound();
    }

    public override void DoUpdate()
    {
        // update all our enemies
        foreach (Enemy enemy in enemies)
        {
            enemy.DoUpdate();
        }
    }

    public override void DoFixedUpdate()
    {
        // fixed update all our enemies
        foreach (Enemy enemy in enemies) 
        {
            enemy.DoFixedUpdate();
        }

        // fixed update our spawners
        foreach(EnemySpawner enemySpawner in enemySpawners) 
        {
            enemySpawner.DoFixedUpdate();
        }

        // remove dead enemies and completed enemySpawners
        RemoveDeadEnemeies();
        RemoveCompletedEnemeySpawners();

        // if we're at the last round and have no more enemies spawning, go to the next round
        if (currentEnemyEvent == currentRound.enemyEvents.Count && enemySpawners.Count == 0)
        {
            EndRound();
        }
        
        // increase our timer if the round timer isn't over
        if (!roundOver)
        {
            eventTimer += Time.deltaTime;
        }

        // start any enemy events that need to be started
        while (currentEnemyEvent < currentRound.enemyEvents.Count && eventTimer >= currentRound.enemyEvents[currentEnemyEvent].startTime)
        {
            StartEnemyEvent(currentRound.enemyEvents[currentEnemyEvent]);
            ++currentEnemyEvent;
        }
    }

    public void SpawnEnemy(EnemyData enemyData) 
    {
        CreateEnemy(enemyData);
    }

    public void NextRound()
    {
        if (!roundManager.IsLastRound())
        {
            roundManager.NextRound();
            ResetRound();
        }
    }

    public void ResetRound()
    {
        currentRound = roundManager.GetCurrentRound();
        eventTimer = 0;
        currentEnemyEvent = 0;
        roundOver = false;
    }

    private void CreateEnemy(EnemyData enemyData)
    {
        Enemy enemy = Instantiate(enemyPrefab, transform);
        enemy.OnCreate(enemyData, pathData);
        enemies.Add(enemy);
    }

    private void RemoveDeadEnemeies()
    {
        for (int i = enemies.Count - 1; i >= 0; --i)
        {
            if (enemies[i].IsDead())
            {
                if (enemies[i].IsFinished())
                {
                    // if they got to the end, take damage equal to their health
                    DealDamage(enemies[i]);
                }
                // either way, get rid of them. For good.
                enemies[i].DoDestroy();
                enemies.RemoveAt(i);
            }
        }
    }

    private void DealDamage(Enemy enemy)
    {
        
    }

    private void RemoveCompletedEnemeySpawners() 
    {
        for (int i = enemySpawners.Count - 1; i >= 0; --i) 
        {
            if (enemySpawners[i].IsFinished())
            {
                enemySpawners.RemoveAt(i);
            }
        }
    }

    private void EndRound()
    {
        roundOver = true;
    }

    private void StartEnemyEvent(EnemyEvent enemyEvent)
    {
        EnemySpawner spawner = new EnemySpawner(enemyEvent.enemyWaveType, this);
        enemySpawners.Add(spawner);
    }
}
