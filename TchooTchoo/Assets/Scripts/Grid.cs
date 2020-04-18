using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Tile[,] tiles;
    public int size;

    public GameObject prefab_tile;

    void Awake()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        tiles = new Tile[size, size];

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                GameObject tileObj = Instantiate(prefab_tile, transform);
                Tile tile = tileObj.GetComponent<Tile>();
                tile.Setup(new Vector2Int(x, y), null, 0.1f);

                tiles[x, y] = tile;
            }
        }
    }

}
