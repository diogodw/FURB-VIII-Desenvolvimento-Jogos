using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public GameObject shoot;
    public int health;
    GameObject a;
    int delay = 0;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) rb.velocity = new Vector2(speed * -1, 0.0f);
        if (Input.GetKey(KeyCode.RightArrow)) rb.velocity = new Vector2(speed, 0.0f);

        if (Input.GetKey(KeyCode.Space) && delay > 500) Shoot();

        delay++;
    }

    public void Damage() 
    {
        health--;

        if (health == 0) Destroy(gameObject);

    }

    void Shoot() 
    {
        delay = 0;
        Instantiate(shoot, a.transform.position, Quaternion.identity);
    }

}
