using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;

[Preserve]
public class SpriteChanger : MonoBehaviour
{
    private Image image;
    private Sprite[] sprites;

    public SpriteChanger(Image image, Sprite[] sprites)
    {
        this.image = image;
        this.sprites = sprites;
    }

    public void ChangeSprite(int index)
    {
        if (index >= 0 && index < sprites.Length) // check if index is within bounds
        {
            image.sprite = sprites[index-1];
        }
    }
}
