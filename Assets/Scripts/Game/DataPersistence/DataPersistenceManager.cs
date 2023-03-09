using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


 public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;
    
    private GameData _gameData;
    
    private List<IDataPersistence> _dataPersistenceObjects;

    private FileDataHandler _dataHandler;
    
    public static DataPersistenceManager instance { get; private set; }
    
    private void Awake()
    {
        if (instance != null)
        { 
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);  
        DontDestroyOnLoad(gameObject);
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded");
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();  
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnLoaded");
        SaveGame();
    }
    
    public void NewGame() => _gameData = new GameData();

    public void LoadGame()
    {
        // TODO - Load any saved data from a file using a data handler
        _gameData = _dataHandler.Load();

        if (_gameData == null)
        {
            return;
        }
        
        // push the loaded data to all other scripts that need it
        
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
    }
    
    public void SaveGame()
    {
        if (_gameData == null)
        {
            return;
        }
        
        // pass the data to other scripts so they can update it        
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref _gameData);
        }
        // TODO - save that data to a file using the data handler
        _dataHandler.Save(_gameData);

    }

    private void OnApplicationQuit() => SaveGame();

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        //IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectOfType<MonoBehaviour>().OfType<IDataPersistence>();
        
        IEnumerable<MonoBehaviour> allMonoBehaviours = FindObjectsOfType<MonoBehaviour>();
        IEnumerable<IDataPersistence> dataPersistenceObjects = allMonoBehaviours.OfType<IDataPersistence>();
        
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return _gameData != null;
    }
    
} 