using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour {

    [HideInInspector]
    public float flightDist;
    [HideInInspector]
    public Vector2 startPos;

    private int rotated = 0;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();       
    }

    void Update () {

        if (rotated < 10)
        {
            float rot = Mathf.Atan2(rb2d.velocity.normalized.x, rb2d.velocity.normalized.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot);
            rotated++;
        }

        if (Vector2.Distance(startPos, transform.position) >= flightDist)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }

}

