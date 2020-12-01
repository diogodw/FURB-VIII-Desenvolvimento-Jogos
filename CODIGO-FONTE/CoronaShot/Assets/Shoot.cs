using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Rigidbody2D rb;
    int dir = 0;
    int speed = 10;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection(int direction)
    {
        dir = direction;
    }

    void Update()
    {
        rb.velocity = new Vector2(dir, speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Shoot") return;
        if (col.gameObject.tag == "Enemy") col.gameObject.GetComponent<Enemy>().Damage();
        if (col.gameObject.tag == "PowerUp") col.gameObject.GetComponent<PowerUp>().Damage();
        
        Destroy(gameObject);
    }

}
