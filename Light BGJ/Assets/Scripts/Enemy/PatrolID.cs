using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolID : MonoBehaviour {

    public int ID = 0;

    void OnValidate()
    {
        gameObject.name = "PatrolPoint ID:" + ID;
    }
}
