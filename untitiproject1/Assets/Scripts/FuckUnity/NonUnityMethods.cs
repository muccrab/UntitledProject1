using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class NonUnityMethods
{
    public static bool IsBetween<T>(this T item, T start, T end)
    {
        return Comparer<T>.Default.Compare(item, start) >= 0
            && Comparer<T>.Default.Compare(item, end) <= 0;
    }


    public static void DestroyAll(GameObject[] gameObjects)
    {
        foreach(GameObject obj in gameObjects)
        {
            MonoBehaviour.Destroy(obj);
        }
    }

    
}
