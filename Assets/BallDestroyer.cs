using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EffectOnBallDestroy(BallStats ballStats);

public class BallDestroyer : MonoBehaviour
{
    public List<BallSpawner> ballSpawnerList;
    public GameManager gameManager;
    public GameObject level;
    
    private ObstacleStats obstacleStats;
    private int destroyerIndex;

    // Start is called before the first frame update
    void Start()
    {
        obstacleStats = level.GetComponent<ObstacleStats>();
        destroyerIndex = StringHelper.GetObjectNum(this.name) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var spawner in ballSpawnerList)
        {
            for (int i = 0; i < spawner.ballList.Count; i++)
            {
                DestroyBall(spawner.ballList[i], spawner.ballList, AddMoney);
            }
        }
    }

    public void DestroyBall(GameObject ball, List<GameObject> ballList, EffectOnBallDestroy effectFunc)
    {
        BallStats ballStats = ball.GetComponent<BallStats>();

        if (ballStats.WasHitByDestroyer(destroyerIndex))
            return;

        Ray ray = new Ray(ball.transform.position, Vector3.down);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 0.2f);

        // if the collider doesnt detect anything, try changing length of the raycast to bigger than radius of a ball
        if (hit.collider)
        {
            if (hit.collider.tag == "BallDestroyer" && hit.collider.name == this.name) // if raycast hits an object that is BallDestroyer
            {
                effectFunc(ballStats);

                ballStats.SetHitByDestroyer(destroyerIndex);

                if (!obstacleStats.isPassedThrough)
                {
                    Destroy(ball);
                    ballList.Remove(ball);   // dont forget to remove from the list the empty object
                }
            }
        }
    }

    protected void AddMoney(BallStats ballStats)
    {
        gameManager.AddMoney(ballStats.ballValue * obstacleStats.obstacleValue);
    }

    public void SetDestroyerPassThrough()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
