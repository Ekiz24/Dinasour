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
        int currentCoins = DataSaveManager.Instance.GetCoins();
        coinText.text = "Coins: " + currentCoins;
    }
}
