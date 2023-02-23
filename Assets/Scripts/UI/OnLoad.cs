using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    [SerializeField] private GameObject image;

    public void Start()
    {
        image.SetActive(false);
    }

}
