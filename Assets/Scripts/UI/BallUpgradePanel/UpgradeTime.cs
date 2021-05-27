using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTime : MonoBehaviour
{
    public GameObject ball;
    public GameObject gameManager;
    public Text buttonText;

    private BallStats ballStats;
    // Start is called before the first frame update
    void Start()
    {
        ballStats = ball.GetComponent<BallStats>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = "Upgrade Time\n$ " + ballStats.spawnTimePrice.ToString("F0");
    }

    public void OnClick()
    {
        if (ballStats.isUnlocked)
        {
            if (gameManager.GetComponent<GameManager>().moneyAmount >= ballStats.spawnTimePrice)
            {
                gameManager.GetComponent<GameManager>().moneyAmount -= ballStats.spawnTimePrice;
                ballStats.spawnTimePrice = Mathf.Round((float)(ballStats.spawnTimePrice * ballStats.spawnTimePriceMultiplier));
                ballStats.spawnTime = ballStats.spawnTime * ballStats.spawnTimeMultiplier;
            }
        }
    }
}
