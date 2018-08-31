using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHammer : MonoBehaviour {
    public float attackRadius;
    public bool inRadius = false;
    public LayerMask stonedThieflayer;
	
	
	// Update is called once per frame
	void Update () {

        Collider2D[] stonedAll = Physics2D.OverlapCircleAll(transform.position, attackRadius, stonedThieflayer);


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           foreach (Collider2D coll in stonedAll)
           {
               EnemyStoneBehaviour stonedScript = coll.GetComponent<EnemyStoneBehaviour>();
               stonedScript.Destruct();
           }
        }
    }
}
