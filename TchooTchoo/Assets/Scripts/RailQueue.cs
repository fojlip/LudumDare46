using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailQueue : MonoBehaviour
{
    public Queue<Rail> queue;

    void Start()
    {
        queue = new Queue<Rail>();
        
        for (int i = 0; i < 250; i++)
        {
            Rail rail = new Rail();
            queue.Enqueue(rail);
        }

    }

}
