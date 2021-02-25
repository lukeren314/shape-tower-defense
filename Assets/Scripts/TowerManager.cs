using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : BaseManager
{
    public EnemyManager enemyManager;
    public ProjectileManager projectileManager;
    public Tower towerPrefab;

    public TowerData testData;
    private List<Tower> towers;

    public override void DoStart()
    {
        towers = new List<Tower>();
        CreateTower(testData, new Vector2(-5, 2));
    }
    public override void DoFixedUpdate() 
    {
        foreach (Tower tower in towers)
        {
            tower.DoFixedUpdate();
        }
    }
    private void CreateTower(TowerData towerData, Vector2 position)
    {
        Tower tower = Instantiate(towerPrefab, transform);
        tower.OnCreate(towerData, enemyManager, projectileManager, position);
        towers.Add(tower);
    }
}
