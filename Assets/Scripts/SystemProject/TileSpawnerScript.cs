using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileSpawnerScript : MonoBehaviour
{
    public GameObject tile;
    public GameObject spawnedTile;
    public List<GameObject> tiles;
    public TileScript spawnedScript;

    public int randomNumber;

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
            for (int j = 0; j <= 5; j++)//go column by column (horizontal)
            {
                randomNumber = Random.Range(1, 7);//select a random number between 1-6
                spawnedTile = Instantiate(tile, transform.position, transform.rotation);//spawn a tile at the current position
                spawnedTile.GetComponent<TileScript>().color = randomNumber;//set the color to something random
                spawnedTile.GetComponent<TileScript>().changeColor();//update the tiles to reflect that color

                transform.position += (Vector3)addToPositionY;//move down
            }
            transform.position = new Vector3(transform.position.x, 4, 0);//go back to the top
            transform.position += (Vector3) addToPositionX;//move right
        }
    }
}
