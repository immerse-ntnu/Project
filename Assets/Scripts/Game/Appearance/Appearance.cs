using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearance : MonoBehaviour
{
    private int hairStyle, skinColor, beard, eyes, hairColor;
    [SerializeField] private Sprite[] images;
    public SpriteRenderer SR;
    public Sprite newSprite;

    public void changeSkin(bool rightButton)
    {
        // If you press right button, go towards right in list
        if (rightButton == true) {skinColor += 1;} 
        else if (rightButton == false) {skinColor -= 1;}
        
        SR.sprite = images[skinColor]; // Change to corresponding skin
    }
    
}
