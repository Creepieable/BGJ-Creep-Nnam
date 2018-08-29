using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour {

    public float threshold;

    private Animator anim;
    private Rigidbody2D rb2d;

    private bool Up;
    private bool Down;
    private bool Left;
    private bool Right;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = rb2d.velocity;
        float velo = Mathf.Abs(velocity.x + velocity.y);
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

        anim.SetBool("MovingUp", Up);
        anim.SetBool("MovingDown", Down);
        anim.SetBool("MovingLeft", Left);
        anim.SetBool("MovingRight", Right);

        if (!Up && !Down && !Left && !Right)
        {
            anim.SetBool("Idle", true);
        }
        else
        {
            anim.SetBool("Idle", false);
        }

    }
}
