using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    public float spawnTime;    
    public Transform enemy;
    public Transform player;
    public Transform explosion;
    private float lastSpawnTime;
    public Transform theDonald;
    public Transform textbox;

    // Use this for initialization
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        double spawnTime = 3;
        if (Time.time > (spawnTime + lastSpawnTime))
        {
            Transform instantiatedEnemy = Instantiate(enemy, transform.position, transform.rotation);
            EnemyController enemyScript = instantiatedEnemy.GetComponent<EnemyController>();
            enemyScript.player = player;
            enemyScript.explosion = explosion;
            enemyScript.theDonald = theDonald;
            enemyScript.textbox = textbox;
            lastSpawnTime = Time.time;
        }

    }
}

