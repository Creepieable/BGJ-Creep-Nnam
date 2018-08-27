using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeahvior : MonoBehaviour
{

    public float acceleration;
    public float maxSpeed;

    public float visionRadius;
    public LayerMask layers;
    public LayerMask wallLayers;

    private Rigidbody2D rb2d;

    private bool inVision;
    private bool isaWall = false;
    private bool detect;

    private Vector2 playerPos;
    private Vector2 direction;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        inVision = Physics2D.OverlapCircle(transform.position, visionRadius, layers);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

        if (inVision)
        {
            Transform playerTransform = Physics2D.OverlapCircle(transform.position, visionRadius, layers).transform;

            playerPos = new Vector2(playerTransform.position.x, playerTransform.position.y);
            direction = playerPos - myPos;

            isaWall = Physics2D.Raycast(transform.position, direction.normalized, Vector2.Distance(myPos, playerPos), wallLayers);

            if (!isaWall)
            {
                detect = true;
            }
           
        }
        else
        {
            detect = false;
        }

        if (detect)
        {
            followPlayer();
        }

    }

    void followPlayer()
    {

        if (rb2d.velocity.magnitude < maxSpeed)
        {
            rb2d.AddForce(direction.normalized * acceleration);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }

}
