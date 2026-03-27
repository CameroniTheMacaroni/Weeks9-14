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

    public GameObject deathScreen;

    public UIBitsScript UIScript;

    public int randomNumber;
    public float spawnSpeed = 0.02f;

    public Vector2 addToPositionX = new Vector2(2, 0);
    public Vector2 addToPositionY = new Vector2(0, -2);

    public UnityEvent onRoundStart;

    public UIBitsScript uiscript;
    public PlayerHitboxScript playerhitboxscript;

    void Start()
    {
        spawnTiles();
        deathScreen.SetActive(false);
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
    public void restartGameAfterDeath()
    {
        onRoundStart.Invoke();//start new round
        deathScreen.SetActive(false);//turn off the death screen
        uiscript.score = 0;//reset score
        uiscript.timerPaused = false;//unpause timer
        playerhitboxscript.isDead = false;//revive player
        spawnSpeed = 0.02f; //reset difficulty
        uiscript.initialTimer = 3;
        uiscript.timer = uiscript.initialTimer;//reset the timer
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
                yield return new WaitForSeconds(spawnSpeed);
            }
            transform.position = new Vector3(transform.position.x, 4, 0);//go back to the top
            transform.position += (Vector3)addToPositionX;//move right
            yield return new WaitForSeconds(spawnSpeed);
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
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    IEnumerator animateTilesRoundOver(int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (tiles[i].GetComponent<TileScript>().color != UIScript.targetColorValue)//if the color of the tile does not match the target color...
            {
                tiles[i].GetComponent<TileScript>().color = 7;//change the color to dark red
                tiles[i].GetComponent<TileScript>().changeColor();//and update to reflect the color change
            }
            yield return new WaitForSeconds(spawnSpeed);
        }
        if (playerhitboxscript.isDead == false)//if the player is still alive...
        {
            yield return new WaitForSeconds(1);
            onRoundStart.Invoke();//start a new round
            uiscript.timerPaused = false;//and unpause the timer
            spawnSpeed -= 0.001f;
        }
        else//if the player is dead
        {
            yield return new WaitForSeconds(0.8f);
            deathScreen.SetActive(true);//show the death screen
        }
    }
}
