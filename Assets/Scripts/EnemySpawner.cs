using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bombEnemy;
    public GameObject followerEnemy;

    private MapGen mapgener;
    
    private float timeLeft;
    private float timeEnemySpawn = 10.0f;

    private void Start()
    {
        mapgener = FindObjectOfType<MapGen>();
        timeLeft = timeEnemySpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            int rand = Random.Range(0, 2);

            switch(rand)
            {
                case 0:
                    spawnEnemy(bombEnemy);
                    break;
                case 1:
                    spawnEnemy(followerEnemy);
                    break;
            }
            
            timeLeft = timeEnemySpawn;
        }

    }

    void spawnEnemy(GameObject enemyToSpawn)
    {
        int ChunkToRemove = Random.Range(mapgener.chunks.Count - 3, mapgener.chunks.Count);
        Vector3 newPos = mapgener.chunks[ChunkToRemove].GetComponent<WorldChunk>().topTile.position + new Vector3(0,5.0f, 0);

        int rand = Random.Range(0, 2);

        Instantiate(enemyToSpawn, newPos, Quaternion.identity);
    }
}
