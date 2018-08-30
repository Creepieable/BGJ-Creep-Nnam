using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public GameObject arrow;

    public float timeBetweenShots;
    public float shotCounter;
    public float tightenTime;

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

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

               while(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    tightenTime += Time.deltaTime;
                }

                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    attack();
                }
                
                
            }
            
        } 
       if (tightenTime > 3)
        {
            tightenTime = 3;
        }
    }


    void attack()
    {
        arrows--;
        shotCounter = timeBetweenShots;
        Instantiate(arrow, rb2d.position, Quaternion.identity);

    }




}
