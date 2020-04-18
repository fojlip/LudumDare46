using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Tile[,] tiles;
    public int size;
    public Tile homeTile;
    public Tile startTile;

    public GameObject prefab_tile;
    public Builder builder;

    void Awake()
    {
        CreateGrid();
        homeTile = tiles[Mathf.RoundToInt((size - 1) / 2), 0];
        startTile = tiles[Mathf.RoundToInt((size - 1) / 2), 1];
        PlaceStartRails();
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

    void PlaceStartRails()
    {
        Rail rail = new Rail()
        {
            type = Rail.Type.NS
        };

        for(int i = 0; i < 3; i++)
        {
            builder.PlaceRail(tiles[Mathf.RoundToInt((size - 1) / 2), i], rail);
        }
    }

}
