using System.Collections;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    public Grid grid;
    public IntVariable score;

    Tile lastTile;
    Tile currentTile;

    readonly float moveTime = 5;

    void Start()
    {
        score.RuntimeValue = 0;

        lastTile = grid.homeTile;
        currentTile = grid.startTile;
        Vector2Int inDirection = lastTile.coords - currentTile.coords;
        transform.transform.position = currentTile.transform.position + new Vector3(inDirection.x, 0, inDirection.y) * 0.5f;

        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(5.0f);
        
        while (true)
        {
            yield return StartCoroutine(MoveOverTile());
            
            Tile nextTile = FindNextTile();
            if (CanMoveToTile(currentTile.coords - nextTile.coords, nextTile))
            {
                Tile temp = currentTile;
                currentTile = nextTile;
                lastTile = temp;

                score.RuntimeValue++;
            }
            else
            {
                //Game end
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator MoveOverTile()
    {
        Vector2Int inDirection = lastTile.coords - currentTile.coords;
        Vector2Int[] currentRailDirections = Rail.RailDirections(currentTile.rail.type);
        Vector2Int outDirection = Vector2Int.zero;

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
            Debug.LogWarning("!!!!");
        }

        float f = 0; 
        while(f < moveTime)
        {
            if(Math.ParallellOrOpposite(new Vector3(inDirection.x,0,inDirection.y), new Vector3(outDirection.x, 0, outDirection.y)))
            {
                transform.position = Vector3.Lerp(currentTile.transform.position + new Vector3(inDirection.x, 0, inDirection.y) * 0.5f,
                    currentTile.transform.position + new Vector3(outDirection.x, 0, outDirection.y) * 0.5f, f / moveTime);
            }
            else
            {
                int sign = Mathf.RoundToInt(Mathf.Sign(Vector2.SignedAngle(inDirection, outDirection)));

                Vector3 point = currentTile.transform.position + new Vector3(inDirection.x, 0, inDirection.y) * 0.5f +
                    new Vector3(outDirection.x, 0, outDirection.y) * 0.5f;
                transform.RotateAround(point, Vector3.up, 90 * 0.01f/3 * sign);
            }

            f += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }

        transform.position = currentTile.transform.position + new Vector3(outDirection.x, 0, outDirection.y) * 0.5f; //new Vector3(outDirection.x, 0, outDirection.y) * 0.5f;
        transform.rotation = Quaternion.LookRotation(new Vector3(outDirection.x, 0, outDirection.y), Vector3.up);
    }

    Tile FindNextTile()
    {
        Tile nextTile = null;
        Vector2Int inDirection = lastTile.coords - currentTile.coords;
        Vector2Int[] currentRailDirections = Rail.RailDirections(currentTile.rail.type);
        Vector2Int outDirection = Vector2Int.zero;    

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

    bool CanMoveToTile(Vector2Int moveDirection, Tile tile)
    {
        if (tile.rail == null)
        {
            Debug.Log("No rail on tile");
            return false;
        }            

        Vector2Int[] railDirection = Rail.RailDirections(tile.rail.type);
        for(int i = 0; i < 2; i ++)
        {
            if (Math.Parallell(new Vector3(railDirection[i].x, 0, railDirection[i].y), new Vector3(moveDirection.x, 0, moveDirection.y)))
            {
                return true;
            }
        }

        Debug.Log("Wrong direction on rail " + moveDirection + " " + railDirection[0] + " " + railDirection[1]);
        return false;
    }



}
