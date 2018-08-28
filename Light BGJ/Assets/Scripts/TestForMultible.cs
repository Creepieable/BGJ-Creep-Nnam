using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForMultible : MonoBehaviour {

    public string[] tags;
    private GameObject[] found; 

	// Use this for initialization
	void Awake(){

        if (tags.Length > 0) {

            for (int i = 0; i < tags.Length; i++)
            {
                found = GameObject.FindGameObjectsWithTag(tags[i]);

                if (found.Length > 1)
                {
                    Debug.LogWarning("Found miltible instances of object with tag: " + tags[i] + " Destroyed multibles...");

                    for (int ii = 1; ii < found.Length - 1; ii++)
                    {
                        Destroy(found[ii]);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Tags string is Empty");
        }

	}
}
