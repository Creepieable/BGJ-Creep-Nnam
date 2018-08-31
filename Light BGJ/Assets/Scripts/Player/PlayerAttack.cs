using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public GameObject arrow;

    public float timeBetweenShots;
    private float shotCounter;
    private float tightenTime;
    public float maxTighten;

    public int arrows;
    

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (shotCounter > 0)
        {
           shotCounter -= Time.deltaTime;
        }
        
       if (arrows > 0 && shotCounter<=0 )
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                realtightenTime += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                attack();
            }
        } 
       if (realtightenTime > maxTighten)
        {
            realtightenTime = maxTighten;
        }
    }


    void attack()
    {
        tightenTime = realtightenTime;
        realtightenTime = 0;
        arrows--;
        shotCounter = timeBetweenShots;
        Instantiate(arrow, rb2d.position, Quaternion.identity);

    }




}
