using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleValueText : MonoBehaviour
{
    public GameObject obstacleSet;

    private ObstacleStats obstacleStats;
    // Start is called before the first frame update
    void Start()
    {
        obstacleStats = obstacleSet.GetComponent<ObstacleStats>();

        ChangeObstacleValueText();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeObstacleValueText();
    }

    // update text
    private void ChangeObstacleValueText()
    {
        if (obstacleStats)
        {
            GetComponent<Text>().text = "Obstacle Value:\nx" + obstacleStats.obstacleValue.ToString("F2");
        }
    }
}
