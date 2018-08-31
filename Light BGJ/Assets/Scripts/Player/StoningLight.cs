using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoningLight : MonoBehaviour {

    public float radius;
    public LayerMask Enemies;
    public LayerMask stoneEnemies;

    // Update is called once per frame
    void Update () {

        Collider2D[] enemysAll = Physics2D.OverlapCircleAll(transform.position, radius, Enemies);
        Collider2D[] enemysStonedAll = Physics2D.OverlapCircleAll(transform.position, radius, stoneEnemies);

        foreach (Collider2D coll in enemysAll)
        {
            coll.GetComponent<Freeze>().FreezeEnemy();
        }

        foreach (Collider2D coll in enemysStonedAll)
        {
            coll.GetComponent<EnemyStoneBehaviour>().Timer = 0;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(63,106,131,1f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
