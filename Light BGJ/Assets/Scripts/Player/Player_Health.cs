using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Health : MonoBehaviour
{

    public int current_player_hp;
    public int max_player_hp;

    public Image[] hearts;
    public Sprite Heart_full;
    public Sprite Heart_empty;

    public float magnitude;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            current_player_hp--;
            var force = transform.position - collision.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);

            if (current_player_hp <= 0)
            {
                Destroy(gameObject);
            }
        }


    }

    private void Update()
    {

        if (current_player_hp > max_player_hp)
        {
            current_player_hp = max_player_hp;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < current_player_hp)
            {
                hearts[i].sprite = Heart_full;
            }
            else
            {
                hearts[i].sprite = Heart_empty;
            }



            if (i < max_player_hp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }
}


