using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    public GameObject ballSpawner;
    public GameObject gameManager;
    public GameObject obstacleSet;

    private BallSpawner bSpawner;
    private GameManager gManager;
    private ObstacleStats oStats;
    // Start is called before the first frame update
    void Start()
    {
        bSpawner = ballSpawner.GetComponent<BallSpawner>();
        gManager = gameManager.GetComponent<GameManager>();
        oStats = obstacleSet.GetComponent<ObstacleStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // 
        if (bSpawner)
        {
            for (int i = 0; i < bSpawner.ballList.Count; i++)
            {
                Ray ray = new Ray(bSpawner.ballList[i].transform.position, Vector3.down);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 0.2f);

                // if the collider doesnt detect anything, try changing length of the raycast to bigger than radius of a ball
                if (hit.collider)
                {
                    if (hit.collider.tag == "BallDestroyer") // if raycast hits an object that is BallDestroyer
                    {
                        BallStats ballStats = bSpawner.ballList[i].GetComponent<BallStats>();

                        gManager.AddMoney(ballStats.ballValue * oStats.obstacleValue);

                        Destroy(bSpawner.ballList[i]);
                        bSpawner.ballList.Remove(bSpawner.ballList[i]);   // dont forget to remove from the list the empty object
                    }
                }
            }
        }
    }
}
