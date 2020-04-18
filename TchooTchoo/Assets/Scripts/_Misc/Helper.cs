using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Security.Cryptography;

//ExtensionMethods


public static class Helper
{

    public static class Directions
    {
        public static Vector3[] dir2D = new Vector3[] { Vector3.right, Vector3.forward, Vector3.left, Vector3.back };
        public static Vector3[] dir3D = new Vector3[] { Vector3.up, Vector3.down, Vector3.right, Vector3.forward, Vector3.left, Vector3.back };
    }
    
    public static GameObject SpawnPrimitive(PrimitiveType primitiveType, Vector3 position, float scale, Color color, bool collider = false)
    {
        GameObject obj = GameObject.CreatePrimitive(primitiveType);
        obj.transform.position = position;
        obj.transform.localScale = Vector3.one * scale;
        obj.GetComponent<Renderer>().material.color = color;
        obj.GetComponent<Collider>().enabled = false;
        return obj;
    }    

    public static IEnumerator MaterialFader(Renderer renderer, Material startMaterial, Material endMaterial, float duration)
    {
        float f = 0;
        while (f < 1)
        {
            renderer.material.Lerp(startMaterial, endMaterial, f);
            f += Time.deltaTime / duration;
            yield return null;
        }

        renderer.material = endMaterial;
    }

    public static IEnumerator Opacity(Renderer renderer, float alpha, float duration)
    {
        float startOpacity = renderer.material.color.a;
        Color startColor = renderer.material.color;
        Color endColor = startColor;
        endColor.a = alpha;

        float f = 0;
        while (f < 1)
        {
            renderer.material.color = Color.Lerp(startColor, endColor, f);
            f += Time.deltaTime / duration;
            yield return null;
        }

        renderer.material.color = endColor;
    }

    public static Transform[] AllChildren(Transform trans)
    {
        List<Transform> children = new List<Transform>();

        foreach(Transform child in trans)
        {
            children.Add(child);
            children.AddRange(AllChildren(child).ToList());
        }

        return children.ToArray();
    }








    public static void AddListener(this EventTrigger trigger, EventTriggerType eventType, System.Action<PointerEventData> listener)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(data => listener.Invoke((PointerEventData)data));
        trigger.triggers.Add(entry);
    }

    public static int FlipCoord(int coord, int length)
    {
        return length - coord - 1;
    }    

    public static void Shuffle<T>(this IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


}
