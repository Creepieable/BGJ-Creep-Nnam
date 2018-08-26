using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public bool random = false;

    [Tooltip("Min change in Size")]
    public float minFlicker = 0.1f;

    [Tooltip("Max change in Size")]
    public float maxFlicker = 0.1f;

    [Tooltip("Time between flickers")]
    [Range(0f, 1f)]
    public float flickerAmmount = 0.25f;
	
    private float timer;

    private bool isbigger;
    private float rndAdd;

    void Start() {
        if (random)
        {
            maxFlicker = minFlicker = Random.Range(0.01f,0.02f);
            flickerAmmount = Random.Range(0.2f, 0.3f);
        }
    }

    void Update () {

        if (timer > flickerAmmount)
        {

            if (!isbigger)
            {
                rndAdd = Random.Range(minFlicker, maxFlicker);

                transform.localScale = new Vector3(transform.localScale.x + rndAdd, transform.localScale.y + rndAdd, 1);               
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - rndAdd, transform.localScale.y - rndAdd, 1);
            }

            isbigger = !isbigger;
            timer = 0;

        }
        else
        {
            timer += Time.deltaTime;
        }
	}
}
