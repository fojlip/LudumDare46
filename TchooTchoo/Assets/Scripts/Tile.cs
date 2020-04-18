using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coords;
    public Rail rail;


    public void Setup(Vector2Int coords, Rail rail, float size)
    {
        this.coords = coords;
        this.rail = rail;

        this.transform.position = new Vector3(coords.x, 0, coords.y) + new Vector3(1,0,1) * size*5;
        this.transform.localScale = Vector3.one * size;
    }

}
