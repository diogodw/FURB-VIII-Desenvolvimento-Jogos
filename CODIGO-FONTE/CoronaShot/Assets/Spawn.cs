using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    public float rate;
    public GameObject[] enemies;
    public GameObject[] powerUps;
    public int enemySpawnCount = 1;
    public int powerUpSpawnCount = 1;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {
        int wave = Manager.Instance.wave;
        for (int i = 0; i < enemySpawnCount; i++) 
        {          
            float enemy = Random.Range(0, wave >= 2 ? 100 : 85);
            SpawnObj(enemies[enemy > 85 ? 1 : 0]);
        }
        if (wave > 1) {
            for (int i = 0; i < powerUpSpawnCount; i++) 
            {       
                if (wave <= 2) break;

                float powerUp = Random.Range(0, 100);

                if (wave > 2 && powerUp >= 90 && powerUp < 94) SpawnObj(powerUps[0]);
                if (wave > 3 && powerUp >= 94 && powerUp < 97) SpawnObj(powerUps[1]);
                if (wave > 4 && powerUp >= 97 && powerUp < 100) SpawnObj(powerUps[2]);
            }
        }
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-4.1f, 8.5f), 5.5f, 7);
    }

    void SpawnObj(GameObject obj)
    {
        Instantiate(obj, RandomPosition(), Quaternion.identity);
    }

}
