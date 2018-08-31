using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStoneBehaviour : MonoBehaviour {
    public GameObject Thief;

    public float stonedTime;
    [HideInInspector]
    public float Timer = 0;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update () {
        Timer += Time.deltaTime;
        if (Timer >= stonedTime)
        {
            Instantiate(Thief, rb2d.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

    public void Destruct()
    {
        Destroy(gameObject);
    }
}
