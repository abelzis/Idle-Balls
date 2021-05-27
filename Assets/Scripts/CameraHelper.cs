using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    public static Collider2D GetColliderHit(Vector2 inputPosition)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(inputPosition);
        var touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos);
        return hit;
    }
}
