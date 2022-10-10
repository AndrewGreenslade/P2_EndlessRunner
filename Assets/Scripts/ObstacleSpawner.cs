
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private GameObject obstacleClone;
    private float timeLeft;
    private float timeObstacleSpawn = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeObstacleSpawn;
      //  InvokeRepeating("spawnEnemy", 2, 2);

    }

    // Update is called once per frame
    void Update()
    {
        timeObstacleSpawn = Random.Range(2, 6);
        

        //InvokeRepeating("spawnEnemy", 10, 10);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            spawnEnemy();
            timeLeft = timeObstacleSpawn;
        }
        
    }

    private void FixedUpdate()
    {

    }


    void spawnEnemy()
    {
        obstacleClone = Instantiate(obstaclePrefab, new Vector2(10.0f,-2.4f), Quaternion.identity);

    }

}