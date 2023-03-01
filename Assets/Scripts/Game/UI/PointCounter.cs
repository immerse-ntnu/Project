using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private Attributes stats;
    [SerializeField] private Sprite[] numbers;
    [SerializeField] private Image image;
    [SerializeField] private GameObject attributesObject;
    
    
    private void Start()
    {
        stats = attributesObject.GetComponent<Attributes>();
    }

    private void UpdateScore()
    {
        int index = stats.currentPoints;
        if (index >= 0 && index < numbers.Length) // Make sure the index is within the bounds of the array
        {
            image.sprite = numbers[index];
        }
    }
    
    private void Update()
    {
        UpdateScore();
    }
}