using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject arrow;

    public float shotForceMultiplier = 1;
    public float shotDistance = 1;
    public float timeBetweenShots;   
    public float maxTighten = 5;
    public int arrows;

    private float shotCounter;
    private float tightenTime = 1;

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
                tightenTime += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                attack();
            }
        } 
       if (tightenTime > maxTighten)
        {
            tightenTime = maxTighten;
        }
    }


    void attack()
    {        
        shotCounter = timeBetweenShots;


        GameObject arrowInstance = Instantiate(arrow, rb2d.position, Quaternion.identity) as GameObject;
        Rigidbody2D arrowRB = arrowInstance.GetComponent<Rigidbody2D>();

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(mouse.normalized * shotForceMultiplier * tightenTime);

        arrowRB.AddForce(mouse.normalized * shotForceMultiplier * tightenTime);

        ArrowBehaviour arrowScript = GetComponent<ArrowBehaviour>();

        arrowScript.startPos = transform.position;

        tightenTime = 1;
        arrows--;
    }

}
