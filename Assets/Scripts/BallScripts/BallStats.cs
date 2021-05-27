using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStats : MonoBehaviour
{
    public bool isUnlocked;
    public double unlockPrice;

    public double ballValue;
    public double ballValueMultiplier;
    public double ballValuePrice;
    public double ballValuePriceMultiplier;

    public double spawnTime;
    public double spawnTimeMultiplier;
    public double spawnTimePrice;
    public double spawnTimePriceMultiplier;

    protected List<bool> wasHitByDestroyer;

    void Start()
    {
        int quantity = 10;
        wasHitByDestroyer = new List<bool>(quantity);
        for (int i = 0; i < quantity; i++)
            wasHitByDestroyer.Add(false);
    }

    public bool WasHitByDestroyer(int index) => wasHitByDestroyer[index];

    public void SetHitByDestroyer(int index) => wasHitByDestroyer[index] = true;
}
