using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail
{
    public enum Type { NS, EW, NE, NW, SW, SE };
    public Type type;

    public Rail()
    {
        type = (Type)Random.Range(0, 5);
    }

    public static Vector2Int[] RailDirections(Type type)
    {
        if(type == Type.NS)
        {
            return new Vector2Int[] { new Vector2Int(0, 1), new Vector2Int(0, -1) };
        }
        else if (type == Type.EW)
        {
            return new Vector2Int[] { new Vector2Int(1, 0), new Vector2Int(-1, 1) };
        }
        else if (type == Type.NE)
        {
            return new Vector2Int[] { new Vector2Int(0, 1), new Vector2Int(-1, 0) };
        }
        else if (type == Type.NW)
        {
            return new Vector2Int[] { new Vector2Int(0, 1), new Vector2Int(-1, 0) };
        }
        else if (type == Type.SW)
        {
            return new Vector2Int[] { new Vector2Int(0, -1), new Vector2Int(-1, 0) };
        }
        else if (type == Type.SE)
        {
            return new Vector2Int[] { new Vector2Int(0, -1), new Vector2Int(1, 0) };
        }
        else
        {
            Debug.LogWarning("Unknown tile type:" + type);
            return default;
        }
    }
    
}
