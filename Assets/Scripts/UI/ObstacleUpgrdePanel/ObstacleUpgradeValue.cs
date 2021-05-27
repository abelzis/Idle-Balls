using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleUpgradeValue : MonoBehaviour
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
        buttonText.text = "Upgrade Value\n$ " + obstacleStats.obstacleValuePrice.ToString("F0");
    }

    public void OnClick()
    {
        if (obstacleStats.isUnlocked)
        {
            if (gameManager.GetComponent<GameManager>().moneyAmount >= obstacleStats.obstacleValuePrice)
            {
                gameManager.GetComponent<GameManager>().moneyAmount -= obstacleStats.obstacleValuePrice;
                obstacleStats.obstacleValuePrice = Mathf.Round((float)(obstacleStats.obstacleValuePrice * obstacleStats.obstacleValuePriceMultiplier)) + 1;
                obstacleStats.obstacleValue = obstacleStats.obstacleValue * obstacleStats.obstacleValueMultiplier;
            }
        }
    }
}
