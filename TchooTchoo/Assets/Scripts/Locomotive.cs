using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    public Grid grid;
    Tile lastTile;
    Tile currentTile;


    void Start()
    {
        lastTile = grid.homeTile;
        currentTile = grid.startTile;
        transform.transform.position = currentTile.transform.position;
    }

    void Update()
    {

    }

    Tile FindNextTile()
    {
        Tile nextTile = null;
        Vector2Int inDirection = currentTile.coords - lastTile.coords;
        Vector2Int[] currentRailDirections = Rail.RailDirections(currentTile.rail.type);
        Vector2Int outDirection = Vector2Int.zero;

        if (Math.ParallellOrOpposite(new Vector3(currentRailDirections[0].x, 0, currentRailDirections[0].y), new Vector3(inDirection.x, 0, inDirection.y)))
        {
            outDirection = currentRailDirections[1];
        }
        else if (Math.ParallellOrOpposite(new Vector3(currentRailDirections[1].x, 0, currentRailDirections[1].y), new Vector3(inDirection.x, 0, inDirection.y)))
        {
            outDirection = currentRailDirections[0];
        }
        else
        {
            Debug.LogWarning("!!!!");
        }

        Vector2Int nextTileCoords = currentTile.coords + outDirection;
        nextTile = grid.tiles[nextTileCoords.x, nextTileCoords.y];
        return nextTile;
    }




}
