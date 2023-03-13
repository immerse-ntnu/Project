using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


 public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    [SerializeField] private bool initializeDataIfNull = false;
    
    private GameData _gameData;
    
    private List<IDataPersistence> _dataPersistenceObjects;

    private FileDataHandler _dataHandler;
    private  Attributes _player;
    
    public static DataPersistenceManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null)
        { 
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        
        _player = FindObjectOfType<Attributes>();
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // ReSharper disable once HeapView.ObjectAllocation.Possible
        // ReSharper disable once HeapView.DelegateAllocation
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        // ReSharper disable once HeapView.ObjectAllocation.Possible
        // ReSharper disable once HeapView.DelegateAllocation
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    
    private void OnDisable()
    {
        // ReSharper disable once HeapView.ObjectAllocation.Possible
        // ReSharper disable once HeapView.DelegateAllocation
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
        // ReSharper disable once HeapView.ObjectAllocation.Possible
        // ReSharper disable once HeapView.DelegateAllocation
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded");
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();  
    }

    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnLoaded");
        SaveGame();
    }
    
    // ReSharper disable once HeapView.ObjectAllocation.Evident
    public void NewGame() => _gameData = new GameData();

    public void LoadGame()
    {
        // TODO - Load any saved data from a file using a data handler
        _gameData = _dataHandler.Load();

        if (_gameData == null && initializeDataIfNull)
        {
            NewGame();
        }
        
        if (_gameData == null)
        {
            return;
        }
        
        // push the loaded data to all other scripts that need it
        foreach (var dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
    }

    private void SaveGame()
    {
        if (_gameData == null)
        {
            Debug.LogWarning("No data was found. A new game needs to be started before data can be saved. ");
            return;
        }
        
        // pass the data to other scripts so they can update it        
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref _gameData);
        }
        
        // save that data to a file using the data handler
        _dataHandler.Save(_gameData);
    }

    private void OnApplicationQuit() => SaveGame();

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<MonoBehaviour> allMonoBehaviours = FindObjectsOfType<MonoBehaviour>();
        IEnumerable<IDataPersistence> dataPersistenceObjects = allMonoBehaviours.OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return _gameData != null;
    }
    
} 