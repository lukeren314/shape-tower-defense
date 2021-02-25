using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // the in-game enemy object
    public EnemyData enemyData;
    public PathData pathData;
    public SpriteRenderer spriteRenderer;
    public EnemyHealthBar healthBar;
    public float currentHealth;
    public bool isDead;
    public bool isFinished;
    public float totalDistance;

    private int currentEdge;
    private float currentEdgeLength;
    private float edgeDistance;

    public void OnCreate(EnemyData enemyData, PathData pathData)
    {
        this.enemyData = enemyData;
        this.pathData = pathData;
        spriteRenderer.sprite = enemyData.sprite;
        spriteRenderer.transform.localScale = new Vector3(enemyData.scale, enemyData.scale);

        // start at max health
        currentHealth = enemyData.health;

        // initialize the first edge
        currentEdge = 0;
        // ASSUME THERE ARE AT LEAST 2 POINTS ON THE PATH
        CalculateEdgeLength();
        edgeDistance = 0;
        totalDistance = 0;
        isDead = false;

        healthBar.UpdateValue(currentHealth, 1);
    }

    public void DoUpdate()
    {
        // we don't want to move the enemy if it's dead
        if (!IsDead())
        {
            // place the enemy where it should be on the current edge
            transform.position = Vector2.Lerp(pathData.points[currentEdge], pathData.points[currentEdge+1], edgeDistance / currentEdgeLength);
        }
    }

    public void DoFixedUpdate()
    {
        // if we've passed the current edge length, move to the next edge
        if (edgeDistance < currentEdgeLength)
        {
            // figure out a good way to calculate how far they should travel every second
            // based on their speed
            float distance = Time.deltaTime * enemyData.speed / 10;
            edgeDistance += distance; //  
            totalDistance += distance;
        } else
        {
            NextEdge();
        }
    }

    public void DoDestroy()
    {
        healthBar.DoDestroy();
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public bool IsFinished()
    {
        return isFinished;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        } else
        {
            healthBar.UpdateValue(currentHealth, currentHealth / enemyData.health);
        }
    }

    private void NextEdge()
    {
        // only move to the next edge if it's not the last, otherwise finish this balloon
        if (currentEdge < pathData.points.Count - 2)
        {
            // subtract the total edge distance travelled and move to the next edge
            edgeDistance -= currentEdgeLength;
            ++currentEdge;
            CalculateEdgeLength();
        } else
        {
            Finish();
        }
    }

    private void CalculateEdgeLength()
    {
        currentEdgeLength = Vector2.Distance(pathData.points[currentEdge], pathData.points[currentEdge + 1]);
    }

    private void Finish()
    {
        // set our flags to true, the enemy manager will clean us up
        isFinished = true;
        Die();
    }

    private void Die()
    {
        spriteRenderer.enabled = false;
        isDead = true;
    }
}
