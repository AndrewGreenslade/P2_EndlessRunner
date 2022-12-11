using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public WorldChunk chunk;
    public List<WorldChunk> chunks = new List<WorldChunk>();
    public GameObject sprite;
    
    public float SquareWidth = 1;
    public float speed = 2;
    private float speedIncreateTimer = 0;
    public float speedIncreateTimeRate = 5.0f;

    Vector2 LowerLeftScreenPos;
    
    public int MaxTiles = 6; //max chunk height
    public int MinTiles = 1; //min chunk height

    // Start is called before the first frame update
    void Start()
    {
        LowerLeftScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        for(int i = 0; i < 25; i++)
        {
            GameObject myChunk = Instantiate(chunk.gameObject, LowerLeftScreenPos + new Vector2(i * SquareWidth, 0), Quaternion.identity,transform);
            WorldChunk theChunk = myChunk.GetComponent<WorldChunk>();
            theChunk.GenerateChunk(4, sprite);
            chunks.Add(theChunk);
        }
    }

    // Update is called once per frame
    void Update()
    {
        manageTimerAndIncreaseSpeed();
        CreateAndSpawnNewChunks();
    }

    private void manageTimerAndIncreaseSpeed()
    {
        speedIncreateTimer += Time.deltaTime;

        if(FindObjectOfType<DistanceScript>().distanceTraveled >= 50.0f)
        {
            speed = 0;
            return;
        }

        if (speedIncreateTimer >= speedIncreateTimeRate)
        {
            speed += 0.35f;
            speedIncreateTimer = 0;
        }
    }

    private void CreateAndSpawnNewChunks()
    {
        for (int i = chunks.Count - 1; i >= 0; i--)
        {
            chunks[i].transform.position = chunks[i].transform.position + -chunks[i].transform.right * Time.deltaTime * speed;

            if (chunks[i].transform.position.x <= LowerLeftScreenPos.x - SquareWidth)
            {
                //destroy old chunk
                GameObject toDestroy = chunks[i].gameObject;
                chunks.Remove(chunks[i]);
                Destroy(toDestroy);

                //spawn new empty chunk
                GameObject myChunk = Instantiate(chunk.gameObject, chunks[chunks.Count - 1].transform.position + new Vector3(SquareWidth, 0, 0), Quaternion.identity, transform);
                WorldChunk theChunk = myChunk.GetComponent<WorldChunk>();

                //see if tile should go one higher , level, or one lower then last tile in list;
                int ShouldTileHeightRise = Random.Range(-1 , 2);
                int NewHeight = chunks[chunks.Count - 1].GetComponent<WorldChunk>().height + ShouldTileHeightRise;

                //limit tiles hieght to min and max value
                NewHeight = Mathf.Clamp(NewHeight, MinTiles, MaxTiles);

                //generate new chunk
                theChunk.GenerateChunk(NewHeight, sprite);
                chunks.Add(theChunk);
            }
        }
    }
}