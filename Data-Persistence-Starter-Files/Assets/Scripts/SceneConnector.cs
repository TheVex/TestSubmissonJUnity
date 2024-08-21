using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneConnector : MonoBehaviour
{
    public static SceneConnector Instance;

    public string playerName;

    public string highScoreName = "None";
    public int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Load();

    }

    [Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void Load() 
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
        
        
        
    }
}
