using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<Sprite> appearance;
    [SerializeField] private SpriteRenderer body, 
        skinColor,
        eyes, 
        hair;
    
    void Start()
    {
        appearance = GetComponent<List<Sprite>>();
    }
    
    public void LoadData(GameData data)
    {
        // Load appearance
        appearance = data.appearance;
    }
    
    public void SaveData(ref GameData data)
    {
        // Save character name
        data.appearance = appearance;
    }

    private void Awake()
    {
        body.sprite = appearance[0];
        skinColor.sprite = appearance[1];
        eyes.sprite = appearance[2];
        hair.sprite = appearance[3];
    }
}
