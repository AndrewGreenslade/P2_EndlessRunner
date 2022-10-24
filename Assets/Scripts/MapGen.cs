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
    
    Vector2 LowerLeftScreenPos;
    
    public int MaxTiles = 6; //max chunk height
    public int MinTiles = 1; //min chunk height


    private void Awake()
    {
        LowerLeftScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        for (int i = 0; i < 25; i++)
        {
            GameObject myChunk = Instantiate(chunk.gameObject, LowerLeftScreenPos + new Vector2(i * SquareWidth, 0), Quaternion.identity, transform);
            WorldChunk theChunk = myChunk.GetComponent<WorldChunk>();
            theChunk.GenerateChunk(4, sprite);
            chunks.Add(theChunk);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("removeRandomChunk", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        CreateAndSpawnNewChunks();
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

    void removeRandomChunk()
    {
        //int ChunkToRemove = Random.Range(chunks.Count - 3, chunks.Count);
        //int childCount = chunks[ChunkToRemove].transform.childCount;
        ////destroy a random chunk between 10-15
        //for (int i = 0;i < childCount;i++)
        //{ 
        //    GameObject toDestroy = chunks[ChunkToRemove].transform.GetChild(i).gameObject;
        //    chunks.Remove(chunks[ChunkToRemove]);
        //    Destroy(toDestroy);
        //    childCount--;
        //}
    }
}
