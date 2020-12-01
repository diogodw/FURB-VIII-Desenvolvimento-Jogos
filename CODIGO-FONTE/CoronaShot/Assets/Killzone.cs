using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<Enemy>().Die();
            GameObject.Find("Player").GetComponent<Player>().Damage();
            return;
        }
        if (col.gameObject.tag == "PowerUp") {
            col.gameObject.GetComponent<PowerUp>().Die();
        }
    }

}
