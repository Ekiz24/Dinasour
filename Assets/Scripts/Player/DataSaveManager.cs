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
    private DataInfo Level1;
    private DataInfo Level2;
    private DataInfo Level3;

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
                    DontDestroyOnLoad(go); // 确保新创建的对象不会被销毁
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

        Level1 = new DataInfo();
        Level1.name = "Level1";
        Level1.counts = 0;

        Level2 = new DataInfo();
        Level2.name = "Level2";
        Level2.counts = 0;

        Level3 = new DataInfo();
        Level3.name = "Level3";
        Level3.counts = 0;

        list.playerDataList.Add(coins);
        list.playerDataList.Add(Level1);
    }

    public void SaveData()
    {
        try
        {
            string json = JsonUtility.ToJson(list);
            string filePath = Application.streamingAssetsPath + "/PlayerDataList.json";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(json);
                sw.Close();
            }
        }
        catch (IOException e)
        {
            Debug.LogError("Error saving data: " + e.Message);
        }
    }

    public void LoadData()
    {
        string filePath = Application.streamingAssetsPath + "/PlayerDataList.json";
        if (File.Exists(filePath))
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string json = sr.ReadToEnd();
                    list = JsonUtility.FromJson<PlayerDataList>(json);
                    sr.Close();
                }
                coins = list.playerDataList.Find(data => data.name == "Coins");
                Level1 = list.playerDataList.Find(data => data.name == "Level1");
                Level2 = list.playerDataList.Find(data => data.name == "Level2");
                Level3 = list.playerDataList.Find(data => data.name == "Level3");
            }
            catch (IOException e)
            {
                Debug.LogError("Error loading data: " + e.Message);
            }
        }
        else
        {
            GenerateData();
            SaveData();
        }
    }

    public void AddCoin()
    {
        if (coins != null)
        {
            coins.counts++;
            SaveData();
            if (coinDisplay != null)
            {
                coinDisplay.UpdateCoinDisplay();
            }
        }
        else
        {
            Debug.LogError("Coins data is not initialized.");
        }
    }

    public void AddPassedLevel1()
    {
        if (Level1 != null)
        {
            Level1.counts++;
            SaveData();
        }
        else
        {
            Debug.LogError("Passed levels data is not initialized.");
        }
    }

    public void AddPassedLevel2()
    {
        if (Level2 != null)
        {
            Level2.counts++;
            SaveData();
        }
        else
        {
            Debug.LogError("Passed levels data is not initialized.");
        }
    }

    public void AddPassedLevel3()
    {
        if (Level3 != null)
        {
            Level3.counts++;
            SaveData();
        }
        else
        {
            Debug.LogError("Passed levels data is not initialized.");
        }
    }

    public int GetCoins()
    {
        return coins != null ? coins.counts : 0;
    }

    public int GetPassedLevel1()
    {
        return Level1 != null ? Level1.counts : 0;
    }

    public int GetPassedLevel2()
    {
        return Level2 != null ? Level2.counts : 0;
    }
    public int GetPassedLevel3()
    {
        return Level3 != null ? Level3.counts : 0;
    }
}


