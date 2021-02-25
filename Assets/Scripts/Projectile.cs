using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum ProjectileType
    {
        NORMAL,
        SEEKING,
        INSTANT
    }

    public ProjectileData projectileData;
    public Tower tower;
    public Enemy target;
    public SpriteRenderer spriteRenderer;

    private List<Enemy> hitEnemies;
    private int hitCount;
    private float distance;
    private float time;
    private bool isFinished;
    public void OnCreate(ProjectileData projectileData, Tower tower, Enemy target)
    {
        this.projectileData = projectileData;
        this.tower = tower;
        this.target = target;
        spriteRenderer.sprite = projectileData.sprite;
        transform.position = tower.transform.position;
        Vector3 diff = target.transform.position - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

        hitEnemies = new List<Enemy>();
        hitCount = 0;
        
    }

    public void DoFixedUpdate()
    {
        switch (projectileData.projectileType)
        {
            case ProjectileType.NORMAL:
                MoveNormal();
                break;
            case ProjectileType.SEEKING:
                MoveSeeking();
                break;
            case ProjectileType.INSTANT:
                MoveInstant();
                break;
        }
        if (distance >= projectileData.range || time > 10)
        {
            Finish();
        } else
        {
            time += Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (!hitEnemies.Contains(enemy))
            {
                enemy.TakeDamage(projectileData.damage);
                hitEnemies.Add(enemy);
                ++hitCount;
                if (hitCount > projectileData.pierce)
                {
                    Finish();
                }
            }
        }
    }

    public bool IsFinished()
    {
        return isFinished;
    }

    public void DoDestroy()
    {
        Destroy(gameObject);
    }

    private void MoveNormal()
    {
        Vector3 movement = transform.rotation * Vector2.right * Time.deltaTime * projectileData.speed;
        transform.position += movement;
        distance += movement.magnitude;
    }

    private void MoveSeeking()
    {
        transform.rotation = Quaternion.FromToRotation(transform.position, target.transform.position);
        MoveNormal();
    }

    private void MoveInstant()
    {

    }

    private void Finish()
    {
        isFinished = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
        if (target != null)
        {
            Gizmos.DrawWireSphere(target.transform.position, 1);
        }
    }
}
