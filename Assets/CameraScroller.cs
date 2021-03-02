using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public float cameraSpeed = 0.5f;
    public float cameraAcceleration = 0.2f;
    public float minY, maxY;

    private Vector2 errorPos;
    private Vector2 prevTouchPos;
    private float speedAfterRelease;

    void Start()
    {
        errorPos = new Vector2(-1000f, -1000f);
        prevTouchPos = errorPos;

        speedAfterRelease = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            //if (prevTouchPos != new Vector2())
            if (prevTouchPos != errorPos)
            {
                speedAfterRelease = (prevTouchPos.y - touchPos.y) * cameraSpeed;
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y + (prevTouchPos.y - touchPos.y) * cameraSpeed * Time.deltaTime);
                if (newPos.y <= maxY && newPos.y >= minY)
                    transform.position = newPos;
            }
            prevTouchPos = touchPos;
        }
        else
        {
            //prevTouchPos = new Vector2();
            prevTouchPos = errorPos;

            if (speedAfterRelease != 0) // if there is inertia
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y + speedAfterRelease * Time.deltaTime);

                // map borders
                if (newPos.y <= maxY && newPos.y >= minY)
                {
                    transform.position = newPos;

                    // scroll directions
                    bool isPositive;
                    if (speedAfterRelease < 0)
                    {
                        isPositive = false;
                        speedAfterRelease = (speedAfterRelease + (cameraAcceleration * cameraSpeed)) * 0.9f;
                    }
                    else
                    {
                        isPositive = true;
                        speedAfterRelease = (speedAfterRelease - (cameraAcceleration * cameraSpeed)) * 0.9f;
                    }


                    // clamp if during the slowdown sign has switched
                    if (isPositive)
                        Mathf.Clamp(speedAfterRelease, 0, speedAfterRelease);
                    else
                        Mathf.Clamp(speedAfterRelease, speedAfterRelease, 0);


                    // if speed is small, end early
                    if (speedAfterRelease < 0.1 && speedAfterRelease > 0)
                        speedAfterRelease = 0;
                    else if (speedAfterRelease > -0.1 && speedAfterRelease < 0)
                        speedAfterRelease = 0;

                }
                else
                {
                    speedAfterRelease = 0;
                }

            }
        }

        //if (Input.GetMouseButton(0))    // if left mouse click pressed
        //{
        //    Vector2 touchPos = Input.mousePosition;

        //    if (prevTouchPos != errorPos)
        //    {
        //        speedAfterRelease = (prevTouchPos.y - touchPos.y) * cameraSpeed;
        //        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + (prevTouchPos.y - touchPos.y) * cameraSpeed * Time.deltaTime);
        //        if (newPos.y <= maxY && newPos.y >= minY)
        //            transform.position = newPos;
        //    }
        //    prevTouchPos = touchPos;
        //}
        //else
        //{
        //    prevTouchPos = errorPos;    // reset previous

        //    if (speedAfterRelease != 0) // if there is inertia
        //    {
        //        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + speedAfterRelease * Time.deltaTime);

        //        map borders
        //        if (newPos.y <= maxY && newPos.y >= minY)
        //        {
        //            transform.position = newPos;

        //            scroll directions
        //            bool isPositive;
        //            if (speedAfterRelease < 0)
        //            {
        //                isPositive = false;
        //                speedAfterRelease = (speedAfterRelease + (cameraAcceleration * cameraSpeed)) * 0.9f;
        //            }
        //            else
        //            {
        //                isPositive = true;
        //                speedAfterRelease = (speedAfterRelease - (cameraAcceleration * cameraSpeed)) * 0.9f;
        //            }


        //            clamp if during the slowdown sign has switched
        //            if (isPositive)
        //                Mathf.Clamp(speedAfterRelease, 0, speedAfterRelease);
        //            else
        //                Mathf.Clamp(speedAfterRelease, speedAfterRelease, 0);


        //            if speed is small, end early
        //            if (speedAfterRelease < 0.1 && speedAfterRelease > 0)
        //                speedAfterRelease = 0;
        //            else if (speedAfterRelease > -0.1 && speedAfterRelease < 0)
        //                speedAfterRelease = 0;

        //        }
        //        else
        //        {
        //            speedAfterRelease = 0;
        //        }

        //    }
        //}


    }
}
