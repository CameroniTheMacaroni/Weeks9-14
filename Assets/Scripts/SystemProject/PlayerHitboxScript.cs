using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxScript : MonoBehaviour
{
    public SpriteRenderer circleSR;
    public SpriteRenderer tileSR;


    public UIBitsScript uiscript;
    public TileSpawnerScript tilespawnerscript;

    void Start()
    {
    }


    void Update()
    {
        if (uiscript.timerPaused == true)
        {

            for (int i = 0; i < tilespawnerscript.tiles.Count; i++)
            {
                tileSR = tilespawnerscript.tiles[i].GetComponent<SpriteRenderer>();
                //Debug.Log(circleSR.bounds.Intersects(tileSR.bounds));
                if (tilespawnerscript.tiles[i].GetComponent<TileScript>().color == 7 && circleSR.bounds.Intersects(tileSR.bounds))
                {
                    Debug.Log("you died");
                }
            }
        }
    }
}
