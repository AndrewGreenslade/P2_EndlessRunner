using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    private GameObject coinClone;
    private float timeLeft;
    private float timeCoinSpawn = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeCoinSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeCoinSpawn = Random.Range(2, 6);


        //InvokeRepeating("spawnEnemy", 10, 10);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            spawnEnemy();
            timeLeft = timeCoinSpawn;
        }

    }


    void spawnEnemy()
    {
        //obstacleClone = Instantiate(obstaclePrefab, new Vector2(10.0f,-2.4f), Quaternion.identity);

        MapGen mapgener = GetComponent<MapGen>();
        int ChunkToRemove = Random.Range(mapgener.chunks.Count - 3, mapgener.chunks.Count);
        Vector3 newPos = mapgener.chunks[ChunkToRemove].GetComponent<WorldChunk>().topTile.position + new Vector3(0, 0.9f, 0);

        coinClone = Instantiate(coinPrefab, newPos, Quaternion.identity, mapgener.chunks[ChunkToRemove].transform);

    }
}
