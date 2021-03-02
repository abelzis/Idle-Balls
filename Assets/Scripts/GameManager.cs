using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public double moneyAmount;
    public Text moneyAmountText;

    //public BallStats ballLevel1;

    //public PanelAnimation upgradePanel;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = 0;
        moneyAmountText.text = "$ " + Mathf.Round((float)moneyAmount).ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = "$ " + Mathf.Round((float)moneyAmount).ToString("F0");
    }

    public void AddMoney(double amount)
    {
        moneyAmount += Mathf.Round((float)amount);
    }



    // UI functions
}
