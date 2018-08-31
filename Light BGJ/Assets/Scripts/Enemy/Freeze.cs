using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {
    public GameObject stonedThief;
    private Rigidbody2D rb2d;
    private bool isStoned = false;

    private void Start()
    {
        rb2d = GetComponent < Rigidbody2D>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            if (!isStoned)
            {
                Instantiate(stonedThief, transform.position, transform.rotation);
                Destroy(gameObject);
                isStoned = true;
            }
        }
    }

}
