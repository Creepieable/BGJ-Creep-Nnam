using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour {

    [HideInInspector]
    public float flightDist;
    [HideInInspector]
    public Vector2 startPos;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();       
    }

    void Update () {

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

