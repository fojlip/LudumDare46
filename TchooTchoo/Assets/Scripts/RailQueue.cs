using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailQueue : MonoBehaviour
{
    public Queue<Rail> queue;

    void Awake()
    {
        queue = new Queue<Rail>();

        Rail firstRail = new Rail()
        {
            type = Rail.Type.NS
        };

        queue.Enqueue(firstRail);


        for (int i = 0; i < 250; i++)
        {
            Rail rail = new Rail();
            queue.Enqueue(rail);
        }

    }

}
