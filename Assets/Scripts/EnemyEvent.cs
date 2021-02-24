using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyEvent
{
    // an enemy event is an enemy wave type and start time
    // after that start time passes, the enemy wave should start
    // spawning
    public EnemyWave enemyWaveType;
    public float startTime;
}
