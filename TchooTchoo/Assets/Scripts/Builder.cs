using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public RailQueue railQueue;
    public VisualizeQueue visualizeQueue;
    public IntVariable railCounter;
    public Locomotive locomotive;

    public void PlaceRail(Tile tile)
    {
        tile.PlaceRail(railQueue.queue.Dequeue());
        visualizeQueue.UpdateVisualization();
        railCounter.RuntimeValue++;
        
        if(railCounter.RuntimeValue == 1)
        {
            locomotive.StartGame();
        }
    }

    public void PlaceRail(Tile tile, Rail rail)
    {
        tile.PlaceRail(rail);
        visualizeQueue.UpdateVisualization();
        //railCounter.RuntimeValue++;
    }

}
