using System;
using System.Collections;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public int color; //decides what color the tile will be, 1-red, 2-blue, 3-yellow, 4-green, 5-orange, 6-purple
    //public ArrayList<Color> colors;
    public SpriteRenderer sprtRen;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void changeColor()
    {
        switch (color)
        {
            case 1:
                sprtRen.color = Color.red;
                break;
            case 2:
                sprtRen.color = Color.blue;
                break;
            case 3:
                sprtRen.color = Color.yellow;
                break;
            case 4:
                sprtRen.color = Color.green;
                break;
            case 5:
                sprtRen.color = Color.orange;
                break;
            case 6:
                sprtRen.color = Color.purple;
                break;
        }
    }
}
