using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBorders : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject leftBorder, rightBorder;

    private Bounds cameraBounds;
    // Start is called before the first frame update
    void Start()
    {
        cameraBounds = OrthographicBounds(mainCamera);
    }

    // Update is called once per frame
    void Update()
    {

        leftBorder.transform.position = new Vector3(-1*cameraBounds.extents.x, cameraBounds.center.y, leftBorder.transform.position.z);
        rightBorder.transform.position = new Vector3(cameraBounds.extents.x, cameraBounds.center.y, leftBorder.transform.position.z);
        //leftBorder.transform.position = new Vector3(-1f*Screen.width/2, Screen.height, leftBorder.transform.position.z);
    }

    public static Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
