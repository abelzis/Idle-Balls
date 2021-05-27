using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBonusSpawner : EventSpawnerBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandlePopupTouch();
    }

    public override void OnClickFunc()
    {
        gameManager.AddMoney(20 * ballManager.GetAllBallAdjustedValue());
        randomEventManager.eligibleForRandomEvent = true;
    }
}
