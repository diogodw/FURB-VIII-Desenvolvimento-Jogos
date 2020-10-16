using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Rigidbody2D rb;
    int dir = 1;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {
        dir *= -1;
    }

    void Update()
    {
        rb.velocity = new Vector2(0, 6 * dir);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") return;
        if (col.gameObject.tag == "Enemy") col.gameObject.GetComponent<Enemy>().Damage();
        
        Destroy(gameObject);
    }

}
