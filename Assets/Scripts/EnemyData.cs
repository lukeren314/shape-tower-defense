using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 3)]
public class EnemyData : ScriptableObject
{
    public float health;
    public float speed;
    public float scale;
    public int numSides;
    public Sprite sprite;
}
