using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    

    public GameObject Healthbar;
    private PlayerTakeDamageBehaviour Player;

    public GameObject Heart;
    public Sprite HeartEmpty;
    public Sprite HeartFull;

    private GameObject[] heart;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamageBehaviour>();

        for (int i = 0; i < Player.playerHp; i++)
        {
            heart[i] = Instantiate(Heart, Healthbar.transform.position, Healthbar.transform.rotation, Healthbar.transform);
        }

        Debug.Log(heart.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
