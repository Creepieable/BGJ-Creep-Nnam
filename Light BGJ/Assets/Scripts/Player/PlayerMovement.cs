using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float acceleration;
    public float maxspeed;
    private Rigidbody2D rb2d;
   
	// Use this for initialization
	void Start (){ 
        // get Rigidbody2D component
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        // get Key-Input 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(horizontal, vertical);
        // apply limited force 
        if (rb2d.velocity.magnitude <= maxspeed)
        {
            rb2d.AddForce(movement * acceleration);
        }

       
       
    }

}
