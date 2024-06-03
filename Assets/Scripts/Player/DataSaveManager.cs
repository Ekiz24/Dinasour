using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class DataInfo
{
    public string name;
    public int counts;
    public bool bools;
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
    private DataInfo ice;
    private DataInfo berry;
    private DataInfo tutorial;

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

        ice = new DataInfo();
        ice.name = "Ice";
        ice.bools = false;

        berry = new DataInfo();
        berry.name = "Berry";
        berry.bools = false;

        tutorial = new DataInfo();
        tutorial.name = "Tutorial";
        tutorial.bools = false;

        list.playerDataList.Add(coins);
        list.playerDataList.Add(Level1);
        list.playerDataList.Add(Level2);
        list.playerDataList.Add(Level3);
        list.playerDataList.Add(ice);
        list.playerDataList.Add(berry);
        list.playerDataList.Add(tutorial);
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
                ice = list.playerDataList.Find(data => data.name == "Ice");
                berry = list.playerDataList.Find(data => data.name == "Berry");
                tutorial = list.playerDataList.Find(data => data.name == "Tutorial");
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
    public void MinusCoin()
    {
        if (coins != null)
        {
            coins.counts--;
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


    public void ActivateIce()
    {
        if (ice != null)
        {
            ice.bools = true;
            SaveData();
        }
        else
        {
            Debug.LogError("Ice Activation is not initialized.");
        }
    }

    public void ActivateBerry()
    {
        if (berry != null)
        {
            berry.bools = true;
            SaveData();
        }
        else
        {
            Debug.LogError("Berry Activation is not initialized.");
        }
    }

    public void SkipTutorial()
    {
        if (tutorial != null)
        {
            tutorial.bools = true;
            SaveData();
        }
        else
        {
            Debug.LogError("Tutorial is not initialized.");
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

    public bool GetIceActivation()
    {
        return ice != null ? ice.bools : false;
    }
    public bool GetBerryActivation()
    {
        return berry != null ? berry.bools : false;
    }
    public bool GetTutorialActivation()
    {
        return tutorial != null ? tutorial.bools : false;
    }
}


