using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Health : MonoBehaviour
{

    public int current_player_hp = 5;
    public int max_player_hp = 5;

    public Image[] hearts;
    public Sprite Heart_full;
    public Sprite Heart_empty;

    private Rigidbody2D rb2d;

    public float magnitude;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

    public void takeDamage(float damage,float knockforce, Transform enimTransform)
    {
        current_player_hp--;
        var dir = transform.position - enimTransform.transform.position;
        dir.Normalize();
        rb2d.AddForce(dir * knockforce);

        if (current_player_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}


