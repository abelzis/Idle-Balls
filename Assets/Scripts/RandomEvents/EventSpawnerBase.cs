using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public delegate void OnClickExecuteStatement();

public abstract class EventSpawnerBase : MonoBehaviour
{
    public int eventWeight;
    public GameObject popup;
    public GameManager gameManager;
    public BallManager ballManager;
    public Camera mainCamera;
    public RandomEventManager randomEventManager;

    protected Bounds cameraBounds;
    protected bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandlePopupTouch()
    {
        if (!isActive)
            return;

        if (Input.touchCount <= 0)
            return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Collider2D hit = CameraHelper.GetColliderHit(Input.GetTouch(i).position);

            if (hit != null && hit.transform == popup.transform) // if raycast hits an object that is ball
            {
                OnClickFunc();

                popup.transform.position = new Vector3(-1000, -1000, 1000);
                isActive = false;
            }
        }
    }

    public abstract void OnClickFunc();

    public void Spawn()
    {
        cameraBounds = ControlBorders.OrthographicBounds(mainCamera);

        float topBorder = cameraBounds.extents.y + mainCamera.transform.position.y;
        float bottomBorder = -1 * cameraBounds.extents.y + mainCamera.transform.position.y;
        float leftBorder = -1 * cameraBounds.extents.x;
        float rightBorder = cameraBounds.extents.x;

        float randomPosX = Random.Range(leftBorder, rightBorder);
        float randomPosY = Random.Range(bottomBorder, topBorder);

        popup.transform.position = new Vector3(randomPosX, randomPosY, 1000);
        isActive = true;
    }
}
