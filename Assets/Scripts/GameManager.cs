using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TowerManager towerManager;
    public EnemyManager enemyManager;
    public PathManager pathManager;
    public RoundManager roundManager;
    public float gameSpeed = 1;

    private void Start()
    {
        towerManager.DoStart();
        enemyManager.DoStart();
        pathManager.DoStart();
        roundManager.DoStart();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        towerManager.DoUpdate();
        enemyManager.DoUpdate();
        pathManager.DoUpdate();
        roundManager.DoUpdate();
    }

    private void FixedUpdate()
    {
        towerManager.DoFixedUpdate();
        enemyManager.DoFixedUpdate();
        pathManager.DoFixedUpdate();
        roundManager.DoFixedUpdate();
    }
}
