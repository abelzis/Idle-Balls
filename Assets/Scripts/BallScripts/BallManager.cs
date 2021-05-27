using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public ObstacleManager obstacleMan;
    public List<GameObject> ballList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    public double GetAllBallValue()
    {
        double value = 0;

        foreach (var ball in ballList)
        {
            BallStats ballStats = ball.GetComponent<BallStats>();
            if (ballStats.isUnlocked)
                value += ballStats.ballValue / ballStats.spawnTime;
        }

        return value;
    }

    public double GetAllBallAdjustedValue()
    {
        return GetAllBallValue() * obstacleMan.GetAllDestroyerValue();
    }
}
