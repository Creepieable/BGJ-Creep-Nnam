using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public float enemy_acceleration;
    public float enemy_maxspeed;
    private Rigidbody2D enemy_rb2d;
 
	// Use this for initialization
	void Start () {
        enemy_rb2d = GetComponent<Rigidbody2D>();
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
	}
}
