using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallTimeText : MonoBehaviour
{
    public GameObject ball;

    private BallStats ballStats;
    // Start is called before the first frame update
    void Start()
    {
        ballStats = ball.GetComponent<BallStats>();

        ChangeBallTimeText();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBallTimeText();
    }

    // update text
    private void ChangeBallTimeText()
    {
        if (ballStats)
        {
            GetComponent<Text>().text = "Spawn Time:\n" + ballStats.spawnTime.ToString("F2") + " sec";
        }
    }
}
