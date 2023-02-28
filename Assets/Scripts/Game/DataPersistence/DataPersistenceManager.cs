using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    
    private string fileName;
    
    private GameData gameData;
    
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;
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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);  
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();    
    }
    
    
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    
    public void LoadGame()
    {
        // TODO - Load any saved data from a file using a data handler
        this.gameData = dataHandler.Load();
        
        
        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        
        // TODO - push the loaded data to all other scripts that need it
    }
    
    public void SaveGame()
    {
        // TODO - pass the data to other scripts so they can update it        
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        
        
        // TODO - save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<MonoBehaviour> allMonoBehaviours = FindObjectsOfType<MonoBehaviour>();
        IEnumerable<IDataPersistence> dataPersistenceObjects = allMonoBehaviours.OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    
}