using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxScript : MonoBehaviour
{
    public bool isDead;

    public SpriteRenderer circleSR;
    public SpriteRenderer tileSR;

    public UIBitsScript uiscript;
    public TileSpawnerScript tilespawnerscript;

    void Start()
    {
    }


    void Update()
    {
        if (uiscript.timerPaused == true && isDead == false)//if the timer has run out...
        {

            for (int i = 0; i < tilespawnerscript.tiles.Count; i++)//go through each tile individually, ...
            {
                tileSR = tilespawnerscript.tiles[i].GetComponent<SpriteRenderer>();//get their sprite renderer...
                if (tilespawnerscript.tiles[i].GetComponent<TileScript>().color == 7 && circleSR.bounds.Intersects(tileSR.bounds))//and check if their sprites intersect with the player's hitbox
                {
                    StartCoroutine(tileFlashOnDeath(i));//make the tile that killed you flash on and off
                    isDead = true;
                }
            }
        }
    }
    IEnumerator tileFlashOnDeath(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            tilespawnerscript.tiles[index].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            tilespawnerscript.tiles[index].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
