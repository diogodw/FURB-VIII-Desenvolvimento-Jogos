using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public float rate;
    public GameObject[] enemies;
    public int enemySpawnCount = 1;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemySpawnCount; i++) {
            Instantiate(enemies[(int) Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.5f, 8.5f), 5.5f, 7), Quaternion.identity);
        }
    }

}
