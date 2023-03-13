using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private readonly string _dataDirPath;
    private readonly string _dataFileName;

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
    }

    public GameData Load()
    {
        var fullPath = Path.Combine(_dataDirPath, _dataFileName);
        GameData loadedData = null;
        if (!File.Exists(fullPath)) 
            return null;
        try
        {
            var dataToLoad = "";
            using (var stream = new FileStream(fullPath, FileMode.Open))
            { 
                using var reader = new StreamReader(stream);
                dataToLoad = reader.ReadToEnd();
            }
            // deserialize data from JSON to C# object
            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            
        }
        catch (Exception e)
        {
            Debug.LogError("Error when trying to load data from file:" + fullPath + "\n" + e);
        }
        Debug.Log(fullPath);
        return loadedData;
    }

    public void Save(GameData data)
    {
        var fullPath = Path.Combine(_dataDirPath, _dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath) ?? string.Empty);
            
            // serialize game data object to JSON
            var dataToStore = JsonUtility.ToJson(data, true);

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            using var stream = new FileStream(fullPath, FileMode.Create);
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            using var writer = new StreamWriter(stream);
            writer.Write(dataToStore);
        }
        catch (Exception e)
        {
            Debug.LogError("Error when trying to save data to file:" + fullPath + "\n" + e);
        }
    }
    
}
