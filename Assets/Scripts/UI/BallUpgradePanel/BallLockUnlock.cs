using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLockUnlock : MonoBehaviour
{
    public GameObject ballLockPanel;
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
        buttonText.text = "Unlock \n$ " + ballStats.unlockPrice.ToString("F0");
    }

    public void OnClick()
    {
        if (!ballStats.isUnlocked)
        {
            if (gameManager.GetComponent<GameManager>().moneyAmount >= ballStats.unlockPrice)
            {
                gameManager.GetComponent<GameManager>().moneyAmount -= ballStats.unlockPrice;
                ballStats.isUnlocked = true;
                Destroy(ballLockPanel);
            }
        }
    }
}
