using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public float health;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().Damage();
            Die();
        }
    }

    public void Damage() 
    {
        health--;

        if (health == 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
