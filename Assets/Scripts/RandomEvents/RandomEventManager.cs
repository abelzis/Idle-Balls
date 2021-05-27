using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    public float minimumTimeBetweenEvents;
    public float maximumTimeBetweenEvents;

    public List<EventSpawnerBase> spawnerList;
    public bool eligibleForRandomEvent;
    //public MoneyBonusSpawner moneyBonusSpawner;
    //public GameSpeedUpEventSpawner gameSpeedUpEventSpawner;

    private int totalWeight;
    private List<int> weightsList;
    private float nextRandomEventTime;
    private float timePassed;
    private int nextRandomEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        totalWeight = 0;
        weightsList = new List<int>();
        for (int i = 0; i < spawnerList.Count; i++)
        {
            totalWeight += spawnerList[i].eventWeight;
            weightsList.Add(spawnerList[i].eventWeight);
        }

        //totalWeight = moneyBonusSpawner.eventWeight + gameSpeedUpEventSpawner.eventWeight;
        eligibleForRandomEvent = true;

        nextRandomEventTime = GetNextRandomTime();
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!eligibleForRandomEvent)
            return;

        timePassed += Time.deltaTime;
        if (timePassed < nextRandomEventTime)
            return;

        timePassed = 0;
        nextRandomEventTime = GetNextRandomTime();
        //nextRandomEvent = 0;
        nextRandomEvent = getNextRandomEvent(weightsList, totalWeight);

        spawnerList[nextRandomEvent].Spawn();
        eligibleForRandomEvent = false;
    }

    protected float GetNextRandomTime()
    {
        return Random.Range(minimumTimeBetweenEvents, maximumTimeBetweenEvents);
    }

    public int getNextRandomEvent(List<int> weights, int weightSum)
    {
        if (weights.Count == 0 || weights == null)
            return -1;

        int rand = Random.Range(0, weightSum);
        int newSum = 0;
        for (int i = 0; i < weights.Count; i++)
        {
            if (weights[i] < 0)
                continue;

            newSum += weights[i];
            if (newSum >= rand)
                return i;
        }

        return -1;
    }
}
