using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoningLight : MonoBehaviour {

    public float radius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(63,106,131,1f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
