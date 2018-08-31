using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject stonedThief;

    public void FreezeEnemy()
    {
        Instantiate(stonedThief, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
