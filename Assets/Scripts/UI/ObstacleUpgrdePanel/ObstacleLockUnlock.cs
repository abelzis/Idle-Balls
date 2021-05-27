using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleLockUnlock : MonoBehaviour
{
    public GameObject obstacleLockPanel;
    public GameObject obstacle;
    public GameObject prevObstacle;
    public GameObject gameManager;
    public Text buttonText;
    public BallDestroyer prevBallDestroyer;

    private ObstacleStats prevLevelObstStats;
    private ObstacleStats obstacleStats;
    // Start is called before the first frame update
    void Start()
    {
        obstacleStats = obstacle.GetComponent<ObstacleStats>();

        if (prevObstacle != null)
            prevLevelObstStats = prevObstacle.GetComponent<ObstacleStats>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = "Unlock \n$ " + obstacleStats.unlockPrice.ToString("F0");
    }

    public void OnClick()
    {
        if (!obstacleStats.isUnlocked)
        {
            if (gameManager.GetComponent<GameManager>().moneyAmount >= obstacleStats.unlockPrice)
            {
                gameManager.GetComponent<GameManager>().moneyAmount -= obstacleStats.unlockPrice;
                obstacleStats.isUnlocked = true;

                if (prevLevelObstStats != null)
                    prevLevelObstStats.isPassedThrough = true;

                prevBallDestroyer.SetDestroyerPassThrough();

                Destroy(obstacleLockPanel);
            }
        }
    }
}
