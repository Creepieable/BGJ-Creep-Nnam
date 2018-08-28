using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public bool take = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gameObject.transform.parent = collision.gameObject.transform;
            take = true;

        }
    }




    void Update()
    {
        if (take == true)
        {
            attack();
        }
    }
        void attack() { 
        if (Input.GetKeyDown(KeyCode.Space)){
            Destroy(gameObject);
        }
    }
}
