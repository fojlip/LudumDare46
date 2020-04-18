using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] groundModels;
    public GameObject frame;
    public Vector2Int coords;
    public Rail rail;

    Builder builder;
    
    private void Start()
    {
        frame.SetActive(false);
        builder = GameObject.Find("Builder").GetComponent<Builder>();
    }

    public void Setup(Vector2Int coords, Rail rail, float size)
    {
        this.coords = coords;
        this.rail = rail;

        this.transform.position = new Vector3(coords.x, 0, coords.y) + new Vector3(1,0,1) * size*5;
        this.transform.localScale = Vector3.one * size;

        GameObject model = Instantiate(groundModels[Random.Range(0, groundModels.Length)], transform);
    }

    private void OnMouseDown()
    {
        if(rail == null)
        {
            builder.PlaceRail(this);
        }
    }

    public void PlaceRail(Rail rail)
    {
        this.rail = rail;

        GameObject railModel = Instantiate(Resources.Load("Rails/" + rail.type.ToString())) as GameObject;
        railModel.transform.parent = transform;
        railModel.transform.localPosition = new Vector3(0, 0.625f, 0);
        railModel.transform.localEulerAngles = new Vector3(0, 180, 0);
    }


    private void OnMouseEnter()
    {
        frame.SetActive(true);
    }

    private void OnMouseExit()
    {
        frame.SetActive(false);
    }

}
