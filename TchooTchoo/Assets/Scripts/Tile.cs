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

        GameObject railModel = Instantiate(Resources.Load("Rails/" + rail.type.ToString())) as GameObject;
        railModel.transform.parent = transform;
        railModel.transform.localPosition = Vector3.zero;
        railModel.transform.localEulerAngles = new Vector3(0, 180, 0);
    }


}
