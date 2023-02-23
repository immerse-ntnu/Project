using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public SpriteChanger spriteChanger;
    public Sprite[] spriteArray;
    private int currentIndex;

    public void OnLeftButtonClick()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = spriteArray.Length - 1;
        }
        spriteChanger.ChangeSprite(spriteArray[currentIndex]);
    }

    public void OnRightButtonClick()
    {
        currentIndex++;
        if (currentIndex >= spriteArray.Length)
        {
            currentIndex = 0;
        }
        spriteChanger.ChangeSprite(spriteArray[currentIndex]);
    }
}