using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    public static Vector3 FlipVectorComponents(Vector3 v)
    {
        Vector3 flippedVector = Vector3.zero;

        int sign = 0;
        for (int i = 0; i < 3; i++)
        {
            if(v[i] != 0)
            {
                sign = (int)v[i];
                break;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (v[i] == 0)
            {
                flippedVector[i] = sign;
            }
            else
            {
                flippedVector[i] = 0;
            }
        }

        return flippedVector;
    }


    public static Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
    {
        var vVector1 = vPoint - vA;
        var vVector2 = (vB - vA).normalized;

        var d = Vector3.Distance(vA, vB);
        var t = Vector3.Dot(vVector2, vVector1);

        if (t <= 0)
            return vA;

        if (t >= d)
            return vB;

        var vVector3 = vVector2 * t;

        var vClosestPoint = vA + vVector3;

        return vClosestPoint;
    }

    public static bool Parallell(Vector3 v1, Vector3 v2)
    {
        if (Vector3.Dot(v1, v2) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool Opposite(Vector3 v1, Vector3 v2)
    {
        if (Vector3.Dot(v1, v2) == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ParallellOrOpposite(Vector3 v1, Vector3 v2)
    {
        if(Parallell(v1,v2) || Opposite(v1,v2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static Vector3 PositiveVector(Vector3 v)
    {
        return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
    }


    public static Vector3 RoundEulerAngles(Vector3 eulerAngles, float roundToNearest)
    {
        Vector3 roundedEulerAngles = Vector3.zero;
        for(int i = 0; i < 3; i++)
        {
            roundedEulerAngles[i] = RoundAngle(eulerAngles[i], roundToNearest); // Mathf.Round(eulerAngles[i] / roundToNearest) * roundToNearest;
        }
        return roundedEulerAngles;
    }

    public static float RoundAngle(float angle, float roundToNearest)
    {
        return Mathf.Round(angle / roundToNearest) * roundToNearest;
    }

    /*
    static int[,] RotateMatrix(int[,] matrix, int n)
    {
        int[,] ret = new int[n, n];

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                ret[i, j] = matrix[n - j - 1, i];
            }
        }

        return ret;
    }
    */


}
