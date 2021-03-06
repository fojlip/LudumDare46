﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualizeQueue : MonoBehaviour
{
    public RailQueue railQueue;
    public GameObject prefab_railIcon;

    void Start()
    {
        UpdateVisualization();
    }

    public void UpdateVisualization()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 7; i >= 0; i--)
        {
            Rail rail = railQueue.queue.ElementAt(i);
            GameObject clone = Instantiate(prefab_railIcon, transform);
            Sprite sprite = Resources.Load<Sprite>("Rails/Pictures/" + rail.type.ToString());
            Image image = clone.GetComponent<Image>();
            image.sprite = sprite;

            if(i == 0)
            {
                clone.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
                //image.
            }
        }
    }

}
