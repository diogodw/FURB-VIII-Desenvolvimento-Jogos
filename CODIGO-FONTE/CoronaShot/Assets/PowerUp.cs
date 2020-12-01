using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public float health;
    public int effect;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, (ySpeed + (PlayerPrefs.GetInt("Wave") / 10)) * -1);        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") Effect();
    }

    public void Damage() 
    {
        health--;

        if (health == 0) Effect();
    }

    public void Die()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 10);
    }

    void Effect()
    {
        var player = GameObject.Find("Player").GetComponent<Player>();
        switch (effect)
        {
            case 1:
                player.Invulnerable();
                break;
            case 2:
                player.BoostOn();
                break;
            case 3:
                player.IncreaseHealth();
                break;
            default:
                break;
        }
        Die();
    }

}
