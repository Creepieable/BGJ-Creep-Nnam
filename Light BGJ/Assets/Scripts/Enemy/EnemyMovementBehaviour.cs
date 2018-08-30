using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour {

    //patrolePoints
    public int pointID;
    private List<Vector2> patrolePoints;

    private int state; //0 idling, 1 patroling, 2 following
    private int prevState;

    //movement
    public float acc = 10;
    public float maxSpeed = 20;

    public LayerMask playerlayer;
    public LayerMask wallLayer;
    public float visionRadius;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        patrolePoints = new List<Vector2>();

        //get every Patrole Point
        GameObject[] allPatrolPoints = GameObject.FindGameObjectsWithTag("Patrole");

        //only take Patrole Points with 
        foreach (GameObject point in allPatrolPoints)
        {
            PatrolID pID = point.GetComponent<PatrolID>();
            if (pID == null)
            {
                Debug.LogError("Patrollpoint " + point.name + " doesn't have a PatrollID attached.");
            }
            else
            {
                if (pID.ID == pointID)
                {
                    patrolePoints.Add(point.transform.position);
                }
            }
        }

        if (patrolePoints.Count <= 0)
        {
            state = 0;
        }
        else
        {
            state = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (detectPlayer())
        {
            prevState = state;
            moveToPosition(GetPlayerPos());
            state = 2;
        }
        else
        {
            state = prevState;   
        }

        if(state == 1)
        {

        }
        else
        {

        }
        
	}

    void moveToPosition(Vector2 newPos)
    {
        Vector2 myPos = transform.position;
        Vector2 direction = newPos - myPos;

        if (rb2d.velocity.magnitude < maxSpeed)
        {
            rb2d.AddForce(direction.normalized * acc);
        }
    }

    bool detectPlayer()
    {
        bool inVision;
        bool isaWall = false;
        bool detect = false;

        inVision = Physics2D.OverlapCircle(transform.position, visionRadius, playerlayer);
        Vector2 myPos = transform.position;        

        if (inVision)
        {
            Transform playerTransform = Physics2D.OverlapCircle(transform.position, visionRadius, playerlayer).transform;

            Vector2 playerPos = new Vector2(playerTransform.position.x, playerTransform.position.y);
            Vector2 direction = playerPos - myPos;

            isaWall = Physics2D.Raycast(transform.position, direction.normalized, Vector2.Distance(myPos, playerPos), wallLayer);

            if (!isaWall)
            {
                detect = true;
            }

        }
        else
        {
            detect = false;
        }

        return detect;
    }

    Vector2 GetPlayerPos()
    {
        Vector2 playerPos;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        return playerPos;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }

}
