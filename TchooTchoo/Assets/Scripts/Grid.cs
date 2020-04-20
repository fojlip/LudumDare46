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

    public GameObject[] obstacleModels_1x1;
    public GameObject[] obstacleModels_2x2;

    int obstacleFreeZone = 4;

    void Awake()
    {
        CreateGrid();
        homeTile = tiles[Mathf.RoundToInt((size - 1) / 2), 0];
        startTile = tiles[Mathf.RoundToInt((size - 1) / 2), 1];
        PlaceObstacles();
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
        
        for (int i = 0; i < 3; i++)
        {
            builder.PlaceRail(tiles[Mathf.RoundToInt((size - 1) / 2), i], rail);
        }        
    }


    void PlaceObstacles()
    {
        for(int i = 0; i < 7; i++)
        {
            int obstaclesSize = Random.Range(1, 3);
            int margin = obstaclesSize - 1;
            Tile obstacleOriginTile = tiles[Random.Range(0, size - margin), 
                Random.Range(0, size - margin)];

            //Kolla så att de inte hamnar på firzonen
            if(obstacleOriginTile.coords.x + obstaclesSize - 1 > size/2 - obstacleFreeZone && obstacleOriginTile.coords.x < size / 2 + obstacleFreeZone &&
               obstacleOriginTile.coords.y < obstacleFreeZone)
            {
                continue;
            }

            //Kolla så att de inte hamnar över andra hinder
            if(ObstacleInArea(obstacleOriginTile.coords, obstaclesSize))
            {
                continue;            
            }

            for (int y = obstacleOriginTile.coords.y; y < obstacleOriginTile.coords.y + obstaclesSize; y++)
            {
                for (int x = obstacleOriginTile.coords.x; x < obstacleOriginTile.coords.x + obstaclesSize; x++)
                {
                    tiles[x, y].obstacle = true;
                }
            }

            if (obstaclesSize == 1)
            {
                GameObject model = Instantiate(obstacleModels_1x1[Random.Range(0, obstacleModels_1x1.Length)], obstacleOriginTile.transform);
                model.transform.localPosition = new Vector3(1, 0, 1) * ((float)obstaclesSize-1) * 5;
            }
            else if (obstaclesSize == 2)
            {
                GameObject model = Instantiate(obstacleModels_2x2[Random.Range(0, obstacleModels_2x2.Length)], obstacleOriginTile.transform);
                model.transform.localPosition = new Vector3(1, 0, 1) * ((float)obstaclesSize-1) * 5;
            }
            else
            {
                Debug.LogWarning("N/A obstacle size: " + obstaclesSize);
            }
        }
    }

    bool ObstacleInArea(Vector2Int origin, int obstaclesSize)
    {
        for (int y = origin.y; y < origin.y + obstaclesSize; y++)
        {
            for (int x = origin.x; x < origin.x + obstaclesSize; x++)
            {
                if (tiles[x, y].obstacle)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
