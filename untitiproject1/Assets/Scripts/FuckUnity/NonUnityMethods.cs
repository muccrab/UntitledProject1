using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonUnityMethods:MonoBehaviour
{
    public static void DestroyAll(GameObject[] gameObjects)
    {
        foreach(GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
    }
}
