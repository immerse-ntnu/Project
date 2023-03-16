using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static void DestroyAllGameObjects()
    {
        var gameObjects = FindObjectsOfType<GameObject>();
        if (gameObjects == null) throw new ArgumentNullException(nameof(gameObjects));

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
