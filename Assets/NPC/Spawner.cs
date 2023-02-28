using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float spawnTimeInterval;
    [SerializeField]
    float spawnPercentChance;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", Random.Range(20, 50), spawnTimeInterval);
    }

    void SpawnEnemy()
    {
        if(Random.Range(1,100) < spawnPercentChance)
            Instantiate(enemy, transform);
    }
}
