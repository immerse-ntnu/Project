using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private Attributes stats;
    private SpriteChanger spriteChanger;
    [SerializeField] private Sprite[] numbers;
    [SerializeField] private Image image;
    [SerializeField] private GameObject attributesObject; // Add a serialized field to hold the game object with the Attributes component
    
    private void Start()
    {
        stats = attributesObject.GetComponent<Attributes>(); // Get the Attributes component from the specified game object
        spriteChanger = new SpriteChanger(GetComponent<Image>(), numbers);
    }

    private void ChangeScore()
    {
        int index = numbers.Length - stats.currentPoints - 1;
        spriteChanger.ChangeSprite(index);
    }
    
    private void Update()
    {
        ChangeScore();
    }
}