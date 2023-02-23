using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharCreationButtons : MonoBehaviour
{
    public Appearance appearance; // Object of appearance
    public Button right, left;
    
    public void Hair()
    {
        right.onClick.AddListener(() => appearance.changeSkin(true));
        left.onClick.AddListener(() => appearance.changeSkin(false));
    }

}
