using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    public int height;
    public Transform topTile;

    public void GenerateChunk(int t_height,GameObject t_sprite)
    {
        height = t_height;

        for (int i = 0; i < t_height; i++)
        {
            GameObject tile = Instantiate(t_sprite, transform.position , Quaternion.identity,transform);
            tile.transform.position = new Vector2(tile.transform.position.x, tile.transform.position.y + (i * tile.GetComponent<Renderer>().bounds.size.y));
            topTile = tile.transform;
        }
    }
}