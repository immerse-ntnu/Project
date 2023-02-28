using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearance : MonoBehaviour
{
    public List<Sprite> appearanceSprites; // List of skin tone sprites
    public Image appearance; // The Image component that displays the current skin tone sprite
    public Button leftButton; // The left navigation button
    public Button rightButton; // The right navigation button

    private int currentSpriteIndex; // The index of the current skin tone sprite in the list

    void Start()
    {
        // Set the initial sprite to the first one in the list
        currentSpriteIndex = 0;
        appearance.sprite = appearanceSprites[currentSpriteIndex];

        // Add listeners to the navigation buttons
        leftButton.onClick.AddListener(OnLeftButtonClick);
        rightButton.onClick.AddListener(OnRightButtonClick);
    }

    public void OnLeftButtonClick()
    {
        // Decrease the sprite index by 1
        currentSpriteIndex--;
        // If we've gone below 0, wrap around to the end of the list
        if (currentSpriteIndex < 0)
        {
            currentSpriteIndex = appearanceSprites.Count - 1;
        }
        // Update the skin tone image with the new sprite
        appearance.sprite = appearanceSprites[currentSpriteIndex];
    }

    public void OnRightButtonClick()
    {
        // Increase the sprite index by 1
        currentSpriteIndex++;
        // If we've gone beyond the end of the list, wrap around to the beginning
        if (currentSpriteIndex >= appearanceSprites.Count)
        {
            currentSpriteIndex = 0;
        }
        // Update the skin tone image with the new sprite
        appearance.sprite = appearanceSprites[currentSpriteIndex];
    }
}