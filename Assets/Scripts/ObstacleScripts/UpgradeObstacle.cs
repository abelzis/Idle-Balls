using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeObstacle : MonoBehaviour
{
    public GameObject obstacleSet;
    public GameObject gameManager;
    public Text buttonText;

    private ObstacleStats obstacleStats;
    // Start is called before the first frame update
    void Start()
    {
        obstacleStats = obstacleSet.GetComponent<ObstacleStats>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = "Upgrade Obstacles\n$ " + obstacleStats.obstacleDifficultyPrice.ToString("F0");
    }

    public void OnClick()
    {
        if (obstacleStats.isUnlocked)
        {
            if (gameManager.GetComponent<GameManager>().moneyAmount >= obstacleStats.obstacleDifficultyPrice)
            {
                gameManager.GetComponent<GameManager>().moneyAmount -= obstacleStats.obstacleDifficultyPrice;
                obstacleStats.obstacleDifficultyPrice = Mathf.Round((float)(obstacleStats.obstacleDifficultyPrice * obstacleStats.obstacleDifficultyPriceMultiplier)) + 1;
                obstacleStats.obstacleDifficulty = obstacleStats.obstacleDifficulty * obstacleStats.obstacleDifficultyMultiplier;
            }
        }
    }
}
