﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : BaseManager
{
    public PathData pathData;

    private void OnDrawGizmos()
    {
        if (pathData != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.white;
            for (int i = 0; i < pathData.points.Count - 1; ++i)
            {
                Gizmos.DrawLine(pathData.points[i], pathData.points[i+1]);
            }
            Gizmos.color = Color.black;
            foreach (Vector2 point in pathData.points)
            {
                Gizmos.DrawSphere(point, 0.1f);
            }
        }

    }
}
