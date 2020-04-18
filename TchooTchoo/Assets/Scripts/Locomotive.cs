using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    public Grid grid;
    Tile lastTile;
    Tile currentTile;
    float timer = 0;
    float moveTime = 5;

    void Start()
    {
        lastTile = grid.homeTile;
        currentTile = grid.startTile;
        transform.transform.position = currentTile.transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > moveTime)
        {
            Tile temp = currentTile;
            currentTile = FindNextTile();
            lastTile = temp;
            
            transform.transform.position = currentTile.transform.position;
            timer = 0;
        }
    }

    Tile FindNextTile()
    {
        Tile nextTile = null;
        Vector2Int inDirection = lastTile.coords - currentTile.coords;
        Vector2Int[] currentRailDirections = Rail.RailDirections(currentTile.rail.type);
        Vector2Int outDirection = Vector2Int.zero;

        /*
        Debug.Log(inDirection + " " + currentTile.coords + " " + lastTile.coords);
        Debug.Log(currentRailDirections[0]);
        Debug.Log(currentRailDirections[1]);
        */

        if (Math.Parallell(new Vector3(currentRailDirections[0].x, 0, currentRailDirections[0].y), new Vector3(inDirection.x, 0, inDirection.y)))
        {
            outDirection = currentRailDirections[1];
        }
        else if (Math.Parallell(new Vector3(currentRailDirections[1].x, 0, currentRailDirections[1].y), new Vector3(inDirection.x, 0, inDirection.y)))
        {
            outDirection = currentRailDirections[0];
        }
        else
        {
            Debug.LogWarning("!!!! " );
        }

        Vector2Int nextTileCoords = currentTile.coords + outDirection;
        nextTile = grid.tiles[nextTileCoords.x, nextTileCoords.y];
        return nextTile;
    }




}
