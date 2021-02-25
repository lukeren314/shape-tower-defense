using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : BaseManager
{
    public Projectile projectilePrefab;

    private List<Projectile> projectiles;
    public override void DoStart()
    {
        projectiles = new List<Projectile>();
    }

    public override void DoUpdate()
    {

    }

    public override void DoFixedUpdate()
    {
        foreach (Projectile projectile in projectiles)
        {
            projectile.DoFixedUpdate();
        }

        RemoveFinishedProjectiles();
    }

    public void SpawnProjectile(ProjectileData projectileData, Tower tower, Enemy target)
    {
        Projectile projectile = Instantiate(projectilePrefab, transform);
        projectile.OnCreate(projectileData, tower, target);
        projectiles.Add(projectile);
    }

    private void RemoveFinishedProjectiles()
    {
        for (int i = projectiles.Count - 1; i >= 0; --i)
        {
            if (projectiles[i].IsFinished())
            {
                projectiles[i].DoDestroy();
                projectiles.RemoveAt(i);
            }
        }
    }
}
