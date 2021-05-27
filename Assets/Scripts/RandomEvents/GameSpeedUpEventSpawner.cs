using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedUpEventSpawner : EventSpawnerBase
{
    public float modifiedTimeScale;
    public float eventDuration;

    private const float baseTimescale = 1;
    private float timePassed;
    private bool isEventActive;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0f;
        isEventActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEventActive)
            timePassed += Time.deltaTime;

        if (timePassed > eventDuration)
        {
            timePassed = 0f;
            isEventActive = false;
            Time.timeScale = baseTimescale;
            randomEventManager.eligibleForRandomEvent = true;
        }

        HandlePopupTouch();
    }

    public override void OnClickFunc()
    {
        Time.timeScale = modifiedTimeScale;
        timePassed = 0f;
        isEventActive = true;
    }
}
