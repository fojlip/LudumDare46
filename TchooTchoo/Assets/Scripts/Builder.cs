using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public RailQueue railQueue;
    public VisualizeQueue visualizeQueue;

    public void PlaceRail(Tile tile)
    {
        tile.PlaceRail(railQueue.queue.Dequeue());
        visualizeQueue.UpdateVisualization();
    }

    public void PlaceRail(Tile tile, Rail rail)
    {
        tile.PlaceRail(rail);
        visualizeQueue.UpdateVisualization();
    }

}
