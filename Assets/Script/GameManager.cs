using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TowerManager towerManager;
    public EnemyManager enemyManager;
    public PathManager pathManager;

    private void Start()
    {
        towerManager.DoStart();
        enemyManager.DoStart();
        pathManager.DoStart();
    }

    private void Update()
    {
        towerManager.DoUpdate();
        enemyManager.DoUpdate();
        pathManager.DoUpdate();
    }
}
