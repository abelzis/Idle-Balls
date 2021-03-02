using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Obstacle : MonoBehaviour
{
    public GameObject obstacleSet;
    public bool isOddNum;

    private ObstacleStats obstacleStats;
    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        obstacleStats = obstacleSet.GetComponent<ObstacleStats>();
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleStats && obstacleStats.isUnlocked && rt)
        {
            // if 1st, 3rd, 5th..
            if (isOddNum)
            {
                Vector3 rotationEuler = new Vector3(0.0f, 0.0f, -90.0f + 90.0f * (float)obstacleStats.obstacleDifficulty); //increment 30 degrees every second
                rt.rotation = Quaternion.Euler(rotationEuler);
            }
            // else if even
            else
            {
                Vector3 rotationEuler = new Vector3(0.0f, 0.0f, 90.0f - 90.0f * (float)obstacleStats.obstacleDifficulty); //increment 30 degrees every second
                rt.rotation = Quaternion.Euler(rotationEuler);
            }
        }
    }
}
