using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public RailQueue railQueue;

    public void PlaceRail(Tile tile)
    {
        tile.PlaceRail(railQueue.queue.Dequeue());
    }

    public void PlaceRail(Tile tile, Rail rail)
    {
        tile.PlaceRail(rail);
    }

}
