using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    private static bool _gameIsPaused;
    public Button pauseButton;
    private static List<Button> buttons;
    [SerializeField] private GameObject image;

    private void Start()
    {
        buttons = new List<Button>(GetComponentsInChildren<Button>());
        buttons.Remove(pauseButton);
    }

    private void Update()
    {
        if (_gameIsPaused) return;
        Time.timeScale = 1;
        foreach (var b in buttons)
        {
            b.enabled = false;
            b.gameObject.SetActive(false);
                
        }
        image.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        _gameIsPaused = true;
        Time.timeScale = 0f;
        foreach (var b in buttons)
        {
            b.enabled = true;
            b.gameObject.SetActive(true);
        }
        
        pauseButton.gameObject.SetActive(false);
        image.SetActive(true);
    }

    public void ResumeGame()
    {
        _gameIsPaused = false;
    }
    
}
