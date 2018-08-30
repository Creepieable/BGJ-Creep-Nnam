using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimationBehaviour : MonoBehaviour {

    public float threshold;

    private Animator anim;
    private Rigidbody2D rb2d;

    private bool Up;
    private bool Down;
    private bool Left;
    private bool Right;

    public string stringUp = "MovingUp";
    public string stringDown = "MovingDown";
    public string stringLeft = "MovingLeft";
    public string stringRight = "MovingRight";
    public string stringIdle = "Idle";


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = rb2d.velocity;
        //Oben
        if (velocity.y > 0 && Mathf.Abs(velocity.y) > threshold && Mathf.Abs(velocity.y) > Mathf.Abs(velocity.x))
        {
            Up = true;
        }
        else
        {
            Up = false;
        }

        if (velocity.y < 0 && Mathf.Abs(velocity.y) > threshold && Mathf.Abs(velocity.y) > Mathf.Abs(velocity.x))
        {
            Down = true;
        }
        else
        {
            Down = false;
        }

        if (velocity.x > 0 && Mathf.Abs(velocity.x) > threshold && Mathf.Abs(velocity.y) <= Mathf.Abs(velocity.x))
        {

            Right = true;
        }
        else
        {
            Right = false;
        }

        if (velocity.x < 0 && Mathf.Abs(velocity.x) > threshold && Mathf.Abs(velocity.y) <= Mathf.Abs(velocity.x))
        {
            Left = true;
        }
        else
        {
            Left = false;
        }

        anim.SetBool(stringUp, Up);
        anim.SetBool(stringDown, Down);
        anim.SetBool(stringLeft, Left);
        anim.SetBool(stringRight, Right);

        if (!Up && !Down && !Left && !Right)
        {
            anim.SetBool(stringIdle, true);
        }
        else
        {
            anim.SetBool(stringIdle, false);
        }

    }
}
