using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    [Tooltip("Min change in Size")]
    public float minFlicker;

    [Tooltip("Max change in Size")]
    public float maxFlicker;

    [Tooltip("Time between flickers")]
    [Range(0f, 1f)]
    public float flickerAmmount;
	
    private float timer;

    private bool isbigger;
    private float rndAdd;


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
