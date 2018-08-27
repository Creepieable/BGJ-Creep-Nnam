using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTakeDamageBehaviour : MonoBehaviour
{

    public int current_player_hp = 5;
    public int max_player_hp = 5;

    public bool GodMode;
    private bool invincible;

    public float invinceDuration;
    private float invinceTime;

    public float blinkTime;
    private float blinkTimer;
    private bool isColored = false;

    private SpriteRenderer spRen;
    public Color blinkColor;
    private Color standardColor;

    private GameObject[] enemys;

    private Rigidbody2D rb2d;

    void Start()
    {
        spRen = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        standardColor = spRen.color;
    }

    private void Update()
    {

        //invincibility timer
        if (!GodMode)
        {
            invincible = true;

            if (invinceTime > 0)
            {
                invinceTime -= Time.deltaTime;
                invincible = true;
            }
            else
            {
                invincible = false;
            }
        }

        //invincibility blink
        if (invincible)
        {
            if (blinkTimer > blinkTime)
            {

                if (!isColored)
                {
                    Debug.Log("Büp");
                    spRen.color = blinkColor;
                }
                else
                {
                    Debug.Log("Bop");
                    spRen.color = standardColor;
                }

                isColored = !isColored;
                blinkTimer = 0;

            }
            else
            {
                blinkTimer += Time.deltaTime;
            }
        }
        else
        {
            isColored = false;
            spRen.color = standardColor;
        }

        //disable collision with every enemy when invincible
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (invincible)
        {
            foreach (GameObject go in enemys)
            {
                Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
            }
        }
        else
        {
            foreach (GameObject go in enemys)
            {
                Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
            }
        }

        //Die if helth <=0
        if (current_player_hp <= 0)
        {
            Die();
        }

        //limit to Max lives
        if (current_player_hp > max_player_hp)
        {
            current_player_hp = max_player_hp;
        }
    }

    public void takeDamage(float damage,float knockforce, GameObject enim)
    {
        if (!GodMode)
        {
            invinceTime = invinceDuration;
        }

            current_player_hp--;
            Vector2 dir = transform.position - enim.transform.position;
            dir.Normalize();
            rb2d.AddForce(dir * knockforce);       
    }

    void Die()
    {
        Destroy(gameObject);
    }

}