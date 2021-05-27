using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCenter : MonoBehaviour
{
    public ObstacleStats obstacleStats;
    public bool clockwise;
    public float speed;

    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
            RotateClockwise(rt, speed);
        else
            RotateAntiClockwise(rt, speed);
    }

    public static void RotateClockwise(RectTransform rt, float speedMultiplier)
    {
        rt.RotateAround(rt.position, Vector3.back, speedMultiplier * Time.deltaTime);
    }

    public static void RotateAntiClockwise(RectTransform rt, float speedMultiplier)
    {
        rt.RotateAround(rt.position, Vector3.forward, speedMultiplier * Time.deltaTime);
    }
}
