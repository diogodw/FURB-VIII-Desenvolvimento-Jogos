using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public float health;
    public Sprite deathSprite;
    public int score;
    bool alive = true;
    private SpriteRenderer spriteRenderer; 

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (alive) 
            rb.velocity = new Vector2(xSpeed, (ySpeed + (Manager.Instance.wave / 10)) * -1);
        else 
            rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!alive) return;
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

    public void Die()
    {
        GetComponent<AudioSource>().Play();
        Manager.Instance.AddScore(score);
        //PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        StartCoroutine(ChangeSpriteAndDie());
    }

    IEnumerator ChangeSpriteAndDie()
    {
        alive = false;

        //CHANGE SPRITE
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deathSprite;

        //DISABLE PHYSICS
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().freezeRotation = true;

        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }

}
