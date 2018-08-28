using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTakeDamageBehaviour : MonoBehaviour
{

    public int playerHp = 5;
    public int maxPlayerHp = 5;

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
                    spRen.color = blinkColor;
                }
                else
                {                   
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
        if (playerHp <= 0)
        {
            Die();
        }

        //limit to Max lives
        if (playerHp > maxPlayerHp)
        {
            playerHp = maxPlayerHp;
        }

        if(playerHp < 0)
        {
            playerHp = 0;
        }
    }

    public void takeDamage(float damage,float knockforce, GameObject enim)
    {
        if (!GodMode)
        {
            invinceTime = invinceDuration;
        }

            playerHp--;
            Vector2 dir = transform.position - enim.transform.position;
            dir.Normalize();
            rb2d.AddForce(dir * knockforce);       
    }

    void Die()
    {
        if (!GodMode)
        {
            Debug.Log("PlayerDeath");
        }
    }

}