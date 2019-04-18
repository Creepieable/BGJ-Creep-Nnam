using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject arrow;

    public float shotForceMultiplier = 1;
    public float shotDistance = 1;
    public float timeBetweenShots;
    public float minTighten = 0;
    public float maxTighten = 5;
    public int arrows;

    private float shotCounter;
    private float tightenTime;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tightenTime = minTighten;
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
        Vector3 mouse = Vector2.zero;

        shotCounter = timeBetweenShots;


        GameObject arrowInstance = Instantiate(arrow, rb2d.position, Quaternion.identity) as GameObject;
        Rigidbody2D arrowRB = arrowInstance.GetComponent<Rigidbody2D>();
        

        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        arrowInstance.transform.Rotate(0, 0, (Mathf.Atan2(mouse.y, mouse.x)-90) * Mathf.Rad2Deg);



        arrowRB.AddForce(mouse.normalized * shotForceMultiplier * tightenTime);

        ArrowBehaviour arrowScript = arrowInstance.GetComponent<ArrowBehaviour>();

        arrowScript.startPos = transform.position;
        arrowScript.flightDist = shotDistance * tightenTime;
        
        tightenTime = minTighten;
        arrows--;
    }

}
