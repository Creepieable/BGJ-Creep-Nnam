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

    private List<GameObject> heartClones;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamageBehaviour>();

        heartClones = new List<GameObject>();

        for (int i = 0; i < Player.playerHp; i++)
        {
            heartClones.Add(Instantiate(Heart, Healthbar.transform.position, Healthbar.transform.rotation, Healthbar.transform) as GameObject);
        }

        Debug.Log(heartClones.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
