using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float multiplier;
    private float timer=0;

    public float standardspeed;
    public float realspeed;
    
    private Vector2 target;

    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        multiplier = GameObject.Find("Player").GetComponent<PlayerAttack>().tightenTime;

    }


    void Update () {
        timer += Time.deltaTime;
        realspeed = standardspeed * multiplier;
        transform.position = Vector2.MoveTowards(transform.position, target, realspeed* Time.deltaTime);

        if (multiplier >=0 && multiplier <= 1)
        {
            if (timer >= 1)
            {
                Destroy(gameObject);
            }
        }

        if (multiplier >= 1 && multiplier <= 2)
        {
            if (timer >= 1.5)
            {
                Destroy(gameObject);
            }
        }

        if (multiplier >= 2 && multiplier <= 3)
        {
            if (timer >= 2)
            {
                Destroy(gameObject);
            }
        }
    }

   
}

