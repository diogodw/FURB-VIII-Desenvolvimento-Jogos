using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public GameObject shoot;
    public Image life;
    public Sprite[] lifeSprites;
    bool boost = false;
    bool invulnerable = false;
    GameObject a;
    bool canShoot = true;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) rb.velocity = new Vector2(speed * -1, 0.0f);
        if (Input.GetKey(KeyCode.RightArrow)) rb.velocity = new Vector2(speed, 0.0f);

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && canShoot) Shoot();

        if (Input.GetKey(KeyCode.Escape) && !Manager.Instance.paused) Manager.Instance.Pause();
    }

    public void Damage() 
    {
        if (invulnerable) return;
        
        int health = GetHealth() - 1;

        if (health < 1) 
        {
            Die();
            return;
        }

        UpdateHealth(health);
    }

    int GetHealth()
    {
        return PlayerPrefs.GetInt("Health");
    }

    void Die() {
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

    public void IncreaseHealth()
    {
        int health = GetHealth();
        
        if (health < 5) UpdateHealth(health + 1);
    }

    public void Invulnerable()
    {
        StartCoroutine(InvulnerableExec());
    }

    IEnumerator InvulnerableExec()
    {
        invulnerable = true;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Player/invulnerable");
        yield return new WaitForSeconds(7);

        for (int i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Player/normal");
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Player/invulnerable");
            yield return new WaitForSeconds(0.3f);            
        }

        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Player/normal");
        invulnerable = false;
    }

    public void BoostOn()
    {
        StartCoroutine(BoostExec());
    }

    IEnumerator BoostExec()
    {
        boost = true;

        yield return new WaitForSeconds(5);

        boost = false;
    }

    void UpdateHealth(int health) 
    {
        PlayerPrefs.SetInt("Health", health);

        // UPDATE LIFEBAR
        GameObject.Find("Life").GetComponent<Image>().sprite = lifeSprites[health - 1];
    }

    void Shoot() 
    {
        canShoot = false;
        StartCoroutine(EnableShoot());
        Instantiate(shoot, a.transform.position, Quaternion.identity);
        if (boost) 
        {
            StartCoroutine(BoostShoots());
        }
    }

    IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(0.1f);

        canShoot = true;
    }

    IEnumerator BoostShoots()
    {
        yield return new WaitForSeconds(0.05f);

        GameObject shootD = Instantiate(shoot, a.transform.position, Quaternion.Euler(new Vector3(0, 0, 45))) as GameObject;
        shootD.SendMessage("ChangeDirection", -5);
        GameObject shootE = Instantiate(shoot, a.transform.position, Quaternion.Euler(new Vector3(0, 0, -45))) as GameObject;
        shootE.SendMessage("ChangeDirection", 5);
    }

}
