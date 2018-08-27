using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageBeahviour : MonoBehaviour {

    public float damage = 1;
    public float knockback = 1000;

	void OnCollisionEnter2D(Collision2D collider) {

        if (collider.gameObject.tag == "Player")
        {
            PlayerTakeDamageBehaviour PLayer = collider.gameObject.GetComponent<PlayerTakeDamageBehaviour>();

            PLayer.takeDamage(damage,knockback,gameObject);
        }

	}
}
