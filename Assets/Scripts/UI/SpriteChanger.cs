using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Image image;

    public void ChangeSprite(Sprite newSprite)
    {
        image.sprite = newSprite;
    }
}