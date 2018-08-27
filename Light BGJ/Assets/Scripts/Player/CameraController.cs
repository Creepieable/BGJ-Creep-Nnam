using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform Player;
    public float lerpTime = 0.05f;

    private Vector3 offset;
    private float trueLerpTime;

	void Awake () {

        offset = new Vector3(0,0,transform.position.z);

        if(Player == null)
        {
            Debug.LogWarning("No Player transform in CameraController.");
        }
	}
	

	void FixedUpdate () {

        if (Player != null)
        {

            trueLerpTime = lerpTime * Vector3.Distance(Player.position, transform.position - offset);

            transform.position = Vector3.Lerp(transform.position, Player.position + offset, lerpTime);

        }

	}
}
