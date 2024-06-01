using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class DataInfo
{
    public string name;
    public int counts;
}

[System.Serializable]
public class PlayerDataList
{
    public List<DataInfo> playerDataList = new List<DataInfo>();
}

public class DataSaveManager : MonoBehaviour
{
    public PlayerDataList list = new PlayerDataList();

    private DataInfo coins;
    private DataInfo passedLevels;

    private static DataSaveManager instance;
    public static DataSaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataSaveManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("DataSaveManager");
                    instance = go.AddComponent<DataSaveManager>();
                }
            }
            return instance;
        }
    }

    private CoinDisplay coinDisplay;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadData();
        coinDisplay = FindObjectOfType<CoinDisplay>();
    }

    void GenerateData()
    {
        coins = new DataInfo();
        coins.name = "Coins";
        coins.counts = 0;

        passedLevels = new DataInfo();
        passedLevels.name = "Passed Levels";
        passedLevels.counts = 0;

        list.playerDataList.Add(coins);
        list.playerDataList.Add(passedLevels);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(list);
        string filePath = Application.persistentDataPath + "/PlayerDataList.json";
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine(json);
            sw.Close();
        }
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/PlayerDataList.json";
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                list = JsonUtility.FromJson<PlayerDataList>(json);
                sr.Close();
            }
            coins = list.playerDataList.Find(data => data.name == "Coins");
            passedLevels = list.playerDataList.Find(data => data.name == "Passed Levels");
        }
        else
        {
            GenerateData();
            SaveData();
        }
    }

    public void AddCoin()
    {
        coins.counts++;
        SaveData();
        if (coinDisplay != null)
        {
            coinDisplay.UpdateCoinDisplay();
        }
    }

    public void AddPassedLevel()
    {
        passedLevels.counts++;
        SaveData();
    }

    public int GetCoins()
    {
        return coins.counts;
    }

    public int GetPassedLevels()
    {
        return passedLevels.counts;
    }
}


