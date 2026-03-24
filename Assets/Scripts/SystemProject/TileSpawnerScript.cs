using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnerScript : MonoBehaviour
{
    public GameObject tile;
    public List<GameObject> tiles;

    public Vector2 addToPositionX = new Vector2(2, 0);
    public Vector2 addToPositionY = new Vector2(0, -2);
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void spawnTiles()
    {
        transform.position = new Vector3(-9, 4, 0);//start at the top left
        for (int i = 0; i <= 10; i++)//go row by row (vertical)
        {
            Instantiate(tile, transform.position, transform.rotation);//spawn a tile at the current position
            for (int j = 0; j <= 5; j++)//go column by column (horizontal)
            {
                Instantiate(tile, transform.position, transform.rotation);//spawn a tile at the current position
                transform.position += (Vector3)addToPositionY;//move down
            }
            transform.position = new Vector3(transform.position.x, 4, 0);//go back to the top
            transform.position += (Vector3) addToPositionX;//move right
        }
    }
}
