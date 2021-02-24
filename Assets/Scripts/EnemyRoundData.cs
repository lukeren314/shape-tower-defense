using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyRoundData", menuName = "ScriptableObjects/EnemyRoundData", order = 4)]
public class EnemyRoundData : ScriptableObject
{
    // enemy rounds contain enemy events, which are an enemy wave and start time
    public List<EnemyEvent> enemyEvents;
}
