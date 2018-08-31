using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {
    public float freezeTime;
    public float freezeUntil;
    public bool freezer = false;

    private void Update()
    {
        if (freezeTime < freezeUntil)
        {
            freezeTime += Time.deltaTime;
            freezer = true;
        }
        else
        {
            freezer = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            freezeTime = 0;
        }
    }

}
