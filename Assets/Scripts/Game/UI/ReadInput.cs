using System;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public string input;

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
}
