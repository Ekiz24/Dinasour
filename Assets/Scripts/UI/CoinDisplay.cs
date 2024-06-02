using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;

    void Start()
    {
        if (coinText == null)
        {
            coinText = GetComponent<Text>();
        }

        if (coinText == null)
        {
            Debug.LogError("No Text component found for coinText");
        }

        // 初始化显示金币数
        UpdateCoinDisplay();
    }

    void Update()
    {
        // 实时更新显示金币数（可选，如果需要频繁更新）
        UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        if (DataSaveManager.Instance == null)
        {
            Debug.LogError("DataSaveManager.Instance is null");
            return;
        }

        int currentCoins = DataSaveManager.Instance.GetCoins();
        if (coinText != null)
        {
            coinText.text = "Coins: " + currentCoins;
        }
        else
        {
            Debug.LogError("coinText is null");
        }
    }
}
