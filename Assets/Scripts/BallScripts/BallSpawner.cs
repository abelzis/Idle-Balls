using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    private BallStats ballStats;

    public List<GameObject> ballList;
    private double timePassed;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ballStats = ball.GetComponent<BallStats>();

        ballList = new List<GameObject>();
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballStats.isUnlocked)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= ballStats.spawnTime)    // is ready to spawn?
            {
                timePassed = 0;

                Vector3 ballPos = new Vector3(transform.position.x, transform.position.y, ball.transform.position.z);
                // spawn object as child object of spawner
                ballList.Add(Instantiate(ball, ballPos, transform.rotation, transform));

                // change the position to spawn a little bit off-set of x axis
                float offset = Random.Range(-3.0f, 3.0f);
                GameObject ballObj = ballList[ballList.Count - 1];
                ballObj.transform.Translate(new Vector3(1.0f, 0f) * offset * Time.deltaTime);
            }
            // hit collider
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    // create a raycast
                    //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    //Ray ray = new Ray(Input.GetTouch(i).position, Vector3.down);
                    //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    var touchPos = new Vector2(wp.x, wp.y);

                    Collider2D hit = Physics2D.OverlapPoint(touchPos);

                    for (int j = 0; j < ballList.Count; j++)    // loop through each ball
                    {
                        if (hit != null && hit.transform == ballList[j].transform) // if raycast hits an object that is ball
                        {
                            BallStats ballStats = ballList[j].GetComponent<BallStats>();

                            gameManager.AddMoney(ballStats.ballValue);

                            Destroy(ballList[j]);
                            ballList.Remove(ballList[j]);   // dont forget to remove from the list the empty object
                        }
                    }
                }
            }

            //if (Input.GetMouseButtonDown(0))
            //{
              
            //    // create a raycast
            //    //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            //    //Ray ray = new Ray(Input.GetTouch(i).position, Vector3.down);
            //    //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            //    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    var touchPos = new Vector2(wp.x, wp.y);

            //    Collider2D hit = Physics2D.OverlapPoint(touchPos);

            //    for (int j = 0; j < ballList.Count; j++)    // loop through each ball
            //    {
            //        if (hit != null && hit.transform == ballList[j].transform) // if raycast hits an object that is ball
            //        {
            //            BallStats ballStats = ballList[j].GetComponent<BallStats>();

            //            gameManager.AddMoney(ballStats.ballValue);

            //            Destroy(ballList[j]);
            //            ballList.Remove(ballList[j]);   // dont forget to remove from the list the empty object
            //        }
            //    }
               
            //}

            //if (Input.GetMouseButtonDown(0))
            //{
            //    // create a raycast
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            //    for (int j = 0; j < ballList.Count; j++)    // loop through each ball
            //    {
            //        if (hit.collider != null && hit.transform == ballList[j].transform) // if raycast hits an object that is ball
            //        {
            //            BallStats ballStats = ballList[j].GetComponent<BallStats>();

            //            gameManager.AddMoney(ballStats.ballValue);

            //            Destroy(ballList[j]);
            //            ballList.Remove(ballList[j]);   // dont forget to remove from the list the empty object
            //        }
            //    }
            //}
        }
    }
}
