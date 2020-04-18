using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coords;
    public Rail rail;

    Builder builder;
    
    private void Start()
    {
        builder = GameObject.Find("Builder").GetComponent<Builder>();
    }

    public void Setup(Vector2Int coords, Rail rail, float size)
    {
        this.coords = coords;
        this.rail = rail;

        this.transform.position = new Vector3(coords.x, 0, coords.y) + new Vector3(1,0,1) * size*5;
        this.transform.localScale = Vector3.one * size;
    }

    private void OnMouseDown()
    {
        if(rail == null)
        {
            Debug.Log("Place");
            builder.PlaceRail(this);
        }
    }

    public void PlaceRail(Rail rail)
    {
        this.rail = rail;

        if(rail.type == Rail.Type.NS)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (rail.type == Rail.Type.EW)
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
        else if (rail.type == Rail.Type.NE)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (rail.type == Rail.Type.NW)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (rail.type == Rail.Type.SW)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (rail.type == Rail.Type.SE)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        else
        {
            Debug.LogWarning("N/A rail type: " + rail.type.ToString());
        }
    }


}
