using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHudManager : MonoBehaviour {

    private PlayerTakeDamageBehaviour Player;

    public GameObject Heart;
    public Sprite HeartEmpty;
    public Sprite HeartFull;

    private int prevHealth;

    private List<GameObject> heartClones;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamageBehaviour>();

        heartClones = new List<GameObject>();

        for (int i = 0; i < Player.maxPlayerHp; i++)
        {
            heartClones.Add(Instantiate(Heart, transform.position, transform.rotation, transform) as GameObject);
        }

        for (int i = 0; i < Player.playerHp; i++)
        {
            heartClones[i].GetComponent<Image>().sprite = HeartFull;
        }
        prevHealth = Player.playerHp;
	}
	
	// Update is called once per frame
	void Update () {


        int diff = Player.maxPlayerHp - Player.playerHp;

        //prevent out of range errors
        if (Player.playerHp <= Player.maxPlayerHp)
        {

            //update to empty hearts
            if (Player.playerHp < prevHealth)
            {
                for (int i = heartClones.Count - 1; i > heartClones.Count - 1 - diff; i--)
                {
                    heartClones[i].GetComponent<Image>().sprite = HeartEmpty;
                }
            }

            //update to full hearts
            if (Player.playerHp > prevHealth)
            {

                for (int i = diff; i < Player.playerHp; i++)
                {
                    heartClones[i].GetComponent<Image>().sprite = HeartFull;
                }
            }

            //call UpdateMaxHearts function when nessesary
            if (Player.maxPlayerHp > heartClones.Count || Player.maxPlayerHp < heartClones.Count)
            {
                UpdateMaxHeart();
            }
        }

        prevHealth = Player.playerHp;
	}

    void UpdateMaxHeart()
    {
        //prevent out of range errors
        if (Player.playerHp <= Player.maxPlayerHp)
        {
            int oldLen = heartClones.Count;

            //update to more hearts
            if (heartClones.Count < Player.maxPlayerHp)
            {
                for (int i = oldLen; i < Player.maxPlayerHp; i++)
                {
                    //Debug.Log("Add");
                    heartClones.Add(Instantiate(Heart, transform.position, transform.rotation, transform) as GameObject);
                }
            }
            //update to less hearts
            if (heartClones.Count > Player.maxPlayerHp)
            {

                for (int i = oldLen - 1; i > Player.maxPlayerHp - 1; i--)
                {
                    //Debug.Log("Remove");
                    Destroy(heartClones[i]);
                    heartClones.Remove(heartClones[i]);
                }
            }
        }
    }
}
