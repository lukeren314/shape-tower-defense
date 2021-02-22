using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private List<Tower> towers;

    public void DoStart()
    {
        
    }

    public void DoUpdate()
    {
        foreach (Tower tower in towers)
        {
            tower.DoUpdate();
        }
    }
}
