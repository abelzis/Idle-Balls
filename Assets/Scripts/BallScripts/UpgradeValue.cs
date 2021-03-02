using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeValue : MonoBehaviour
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
        buttonText.text = "Upgrade Value\n$ " + ballStats.ballValuePrice.ToString("F0");
    }
    
    public void OnClick()
    {
        if (ballStats.isUnlocked)
        {
            if (gameManager.GetComponent<GameManager>().moneyAmount >= ballStats.ballValuePrice)
            {
                gameManager.GetComponent<GameManager>().moneyAmount -= ballStats.ballValuePrice;
                ballStats.ballValuePrice = Mathf.Round((float)(ballStats.ballValuePrice * ballStats.ballValuePriceMultiplier)) + 1;
                ballStats.ballValue = Mathf.Round((float)(ballStats.ballValue * ballStats.ballValueMultiplier)) + 1;
            }
        }
    }
}
