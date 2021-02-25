using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TowerManager towerManager;
    public EnemyManager enemyManager;
    public PathManager pathManager;
    public RoundManager roundManager;
    public ProjectileManager projectileManager;

    [Range(0.0f, 2.0f)]
    public float gameSpeed = 1;

    private void Start()
    {
        towerManager.DoStart();
        enemyManager.DoStart();
        pathManager.DoStart();
        roundManager.DoStart();
        projectileManager.DoStart();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        towerManager.DoUpdate();
        enemyManager.DoUpdate();
        pathManager.DoUpdate();
        roundManager.DoUpdate();
        projectileManager.DoUpdate();
    }

    private void FixedUpdate()
    {
        towerManager.DoFixedUpdate();
        enemyManager.DoFixedUpdate();
        pathManager.DoFixedUpdate();
        roundManager.DoFixedUpdate();
        projectileManager.DoFixedUpdate();
    }
}
