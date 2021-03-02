using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallValueText : MonoBehaviour
{
    public GameObject ball;

    private BallStats ballStats;
    // Start is called before the first frame update
    void Start()
    {
        ballStats = ball.GetComponent<BallStats>();

        ChangeBallValueText();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBallValueText();
    }

    // update text
    private void ChangeBallValueText()
    {
        if (ballStats)
        {
            GetComponent<Text>().text = "Ball Value:\n$ " + ballStats.ballValue.ToString("F0");
        }
    }
}
