using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : BaseManager
{
    public List<EnemyRoundData> rounds;
    public int currentRoundIndex;

    public int GetCurrentRoundNumber() 
    {
        return currentRoundIndex + 1;
    }

    public EnemyRoundData GetCurrentRound() 
    {
        return rounds[currentRoundIndex];
    }
    
    public bool IsLastRound()
    {
        return currentRoundIndex == rounds.Count - 1;
    }
    
    public void NextRound()
    {
        if (!IsLastRound())
        {
            ++currentRoundIndex;
        }
    }
}
