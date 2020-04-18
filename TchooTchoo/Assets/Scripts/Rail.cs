using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail
{
    public enum Type { Straight, NE, NW, SW, SE };
    public Type type;

    public Rail()
    {
        type = (Type)Random.Range(0, 5);
    }
    
}
