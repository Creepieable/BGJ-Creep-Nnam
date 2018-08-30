using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float multiplier;

    public float standardspeed;
    public float realspeed;
    
    private Vector2 target;

    


    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        multiplier = GameObject.Find("Player").GetComponent<PlayerAttack>().tightenTime;
        

    }


    void Update () {
        realspeed = standardspeed * multiplier;
        transform.position = Vector2.MoveTowards(transform.position, target, realspeed* Time.deltaTime);
    }

   
}

