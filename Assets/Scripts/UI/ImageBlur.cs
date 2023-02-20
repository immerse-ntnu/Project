using UnityEngine;
using UnityEngine.UI;

public class ImageBlur : MonoBehaviour
{
    [SerializeField] private GameObject blurredImage;
    
    public void DeBlur()
    {
        blurredImage.SetActive(false);
    }
    
    public void Blur()
    {
        blurredImage.SetActive(true);
    }
}