﻿using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionScreen : MonoBehaviour
{
    [Header("Menu Buttons")] 
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;

    private void Update()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DisableButtons();
        
        // Create new game
        DataPersistenceManager.Instance.NewGame();
        
        // Load the gameplay scene
        SceneManager.LoadSceneAsync("CharacterCreation");
    }

    public void OnLoadGameClicked()
    {
        DisableButtons();
        SceneManager.LoadSceneAsync("Game");
    }

    private void DisableButtons()
    {
        newGameButton.interactable = false;
        loadGameButton.interactable = false;
    }
}
