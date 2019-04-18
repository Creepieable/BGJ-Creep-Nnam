using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHammer : MonoBehaviour {
    public float attackRadius;
    public LayerMask stonedThieflayer;

    public bool superHammer = false;
	
	// Update is called once per frame
	void Update () {

        Collider2D[] stonedInReach = Physics2D.OverlapCircleAll(transform.position, attackRadius, stonedThieflayer);

        if (Input.GetButtonDown("Fire2"))
        {
                //killall
                foreach (Collider2D coll in stonedInReach)
                {
                    EnemyStoneBehaviour stonedScript = coll.GetComponent<EnemyStoneBehaviour>();
                    stonedScript.Destruct();
                }           
        }
    }
}
