using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> levelsList;
    public double GetAllDestroyerValue()
    {
        double value = 0;

        foreach (var level in levelsList)
        {
            ObstacleStats levelStats = level.GetComponent<ObstacleStats>();
            if (levelStats.isUnlocked)
                value += levelStats.obstacleValue / levelStats.obstacleDifficulty;
        }

        return value;
    }
}
