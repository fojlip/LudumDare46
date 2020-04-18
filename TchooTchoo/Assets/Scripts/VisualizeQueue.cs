using System.Linq;
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
        for(int i = 0; i < 8; i++)
        {
            Rail rail = railQueue.queue.ElementAt(i);

            GameObject clone = Instantiate(prefab_railIcon, transform);
            clone.GetComponent<TextMeshProUGUI>().text = rail.type.ToString();
        }
    }

}
