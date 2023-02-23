using UnityEngine;

public class ImageBlur : MonoBehaviour
{
    [SerializeField] private GameObject blurredImage;
    [SerializeField] private GameObject stuff;

    public void DeBlur()
    {
        blurredImage.SetActive(false);
    }

    public void Blur()
    {
        blurredImage.SetActive(true);
    }
}    