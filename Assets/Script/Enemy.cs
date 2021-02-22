using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PathData pathData;
    public EnemyData enemyData;
    public float currentHealth;

    private int currentEdge;
    private float currentEdgeLength;
    private float edgeDistance;
    private float totalDistance;

    public void DoUpdate()
    {
        // move to current edge distance
        
    }

    public void FixedUpdate()
    {
        if (edgeDistance < currentEdgeLength)
        {
            edgeDistance += Time.deltaTime * enemyData.speed;
        } else
        {
            NextEdge();
        }
    }
    private void NextEdge()
    {
        ++currentEdge;
        if (currentEdge < pathData.points.Count)
        {
            currentEdgeLength = Vector2.Distance(pathData.points[currentEdge], pathData.points[currentEdge + 1]);
        } else
        {
            DealDamage();
        }
    }
    private void DealDamage()
    {
        Destroy(this);
    }
}
