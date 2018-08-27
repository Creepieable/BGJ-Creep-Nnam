using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    public int player_hp;
    public float magnitude;

    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.gameObject.tag == "Enemy")
        {
            player_hp--;
            var force = transform.position - collision.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);

        }

        if (player_hp <= 0)
        {
            Destroy(gameObject);
        }    
        
    }
}
