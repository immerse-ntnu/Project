using System;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public string Input { get; private set; }

    public void ReadStringInput(string s)
    {
        Input = s;
        Debug.Log(Input);
    }
}
