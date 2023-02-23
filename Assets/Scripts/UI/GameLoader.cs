using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    public void LoadMainMenu() // Load main menu buddy
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSelection() // Load scene for selection menu
    {
        SceneManager.LoadScene("Selection");
    }
    
    public void LoadSettings() // Load scene for settings menu
    {
        SceneManager.LoadScene("Settings");
    }
    
    public void LoadCreation() // Load scene for character creation menu
    {
        SceneManager.LoadScene("CharacterCreation");
    }
}
