 using UnityEngine;
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
            Debug.LogError("Found more than one manager in the scene. Remove excess.");
        }

        instance = this;
    }

    private void Start()
    {
        _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);  
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();    
    }
    
    
    public void NewGame()
    {
        _gameData = new GameData();
    }
    
    public void LoadGame()
    {
        // TODO - Load any saved data from a file using a data handler
        _gameData = _dataHandler.Load();
        
        
        if (_gameData == null)
        {
            NewGame();
        }
        // push the loaded data to all other scripts that need it
        
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
        Debug.Log("Loaded name: " + _gameData.name);
        Debug.Log("Loaded points: " + _gameData.currentPoints);
    }
    
    public void SaveGame()
    {
        // TODO - pass the data to other scripts so they can update it        
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref _gameData);
        }
        // TODO - save that data to a file using the data handler
        _dataHandler.Save(_gameData);
        
        Debug.Log("Loaded name: " + _gameData.name);

    }

    private void OnApplicationQuit() => SaveGame();

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        //IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectOfType<MonoBehaviour>().OfType<IDataPersistence>();
        
        IEnumerable<MonoBehaviour> allMonoBehaviours = FindObjectsOfType<MonoBehaviour>();
        IEnumerable<IDataPersistence> dataPersistenceObjects = allMonoBehaviours.OfType<IDataPersistence>();
        
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    
} 