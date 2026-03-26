using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TileSpawnerScript : MonoBehaviour
{
    public GameObject tile;
    public GameObject spawnedTile;
    public List<GameObject> tiles;
    public TileScript spawnedScript;

    public UIBitsScript UIScript;

    public int randomNumber;

    public Vector2 addToPositionX = new Vector2(2, 0);
    public Vector2 addToPositionY = new Vector2(0, -2);

    public UnityEvent onRoundStart;

    public UIBitsScript uiscript;

    void Start()
    {
        spawnTiles();
    }

    
    void Update()
    {
        
    }
    public void spawnTiles()
    {
        StartCoroutine(animateTilesSpawn());
    }
    public void clearTiles()
    {
        StartCoroutine(animateTilesClear(tiles.Count));
    }
    public void tilesRoundOver()
    {
        StartCoroutine(animateTilesRoundOver(tiles.Count));
    }


    IEnumerator animateTilesSpawn()
    {
        transform.position = new Vector3(-9, 6, 0);//start at the top left
        for (int i = 0; i <= 9; i++)//go row by row (vertical)
        {
            for (int j = 0; j <= 5; j++)//go column by column (horizontal)
            {
                randomNumber = Random.Range(1, 7);//select a random number between 1-6
                spawnedTile = Instantiate(tile, transform.position, transform.rotation);//spawn a tile at the current position
                spawnedTile.GetComponent<TileScript>().color = randomNumber;//set the color to something random
                spawnedTile.GetComponent<TileScript>().changeColor();//update the tiles to reflect that color

                tiles.Add(spawnedTile);//adding the spawned tile to the arraylist

                transform.position += (Vector3)addToPositionY;//move down
                yield return new WaitForSeconds(0.02f);
            }
            transform.position = new Vector3(transform.position.x, 4, 0);//go back to the top
            transform.position += (Vector3)addToPositionX;//move right
            yield return new WaitForSeconds(0.02f);

        }
    }
    IEnumerator animateTilesClear(int length)
    {
        for (int i = 0; i < length; i++)
        {

            Destroy(tiles[0]);
            tiles.Remove(tiles[0]);

            if (i == 10)
            {
                StartCoroutine(animateTilesSpawn());
            }
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator animateTilesRoundOver(int length)
    {
        Debug.Log("round over");

        for (int i = 0; i < length; i++)
        {
            if (tiles[i].GetComponent<TileScript>().color != UIScript.targetColorValue)//if the color of the tile does not match the target color...
            {
                tiles[i].GetComponent<TileScript>().color = 7;//change the color to dark red
                tiles[i].GetComponent<TileScript>().changeColor();//and update to reflect the color change
            }
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1);
        uiscript.timerPaused = false;
        onRoundStart.Invoke();
    }
}
