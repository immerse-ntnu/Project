using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;


public class GameLoader : MonoBehaviour
{
    private GameData _gameData;

    private DataPersistenceManager _dataManager;

    public static void LoadMainMenu() // Load main menu buddy
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

    public void OnSaveButtonClicked()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    
    public void LoadDungeon()
    {
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync("Dungeon");

    }

}
