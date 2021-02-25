using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObjects/ProjectileData", order = 6)]
public class ProjectileData : ScriptableObject
{
    public Projectile.ProjectileType projectileType;
    public float damage;
    public float speed;
    public int pierce;
    public float range;
    public bool explosion;
    public int explosionRadius;
    public Sprite sprite;
}
