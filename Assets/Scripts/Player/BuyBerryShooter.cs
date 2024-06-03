using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBerryShooter : MonoBehaviour
{
    public Button BuyBerryButton;
    public GameObject notEnoughCoins;

    private void Start()
    {
        bool activation = DataSaveManager.Instance.GetBerryActivation();

        if (activation == true)
        {
            BuyBerryButton.interactable = false;
        }
        else
        {
            BuyBerryButton.interactable = true;
        }
    }

    public void BuyBerry()
    {
        int coins = DataSaveManager.Instance.GetCoins();
        if (coins >= 40)
        {
            for (int i = 0; i < 40; i++)
            {
                DataSaveManager.Instance.MinusCoin();
            }
            BuyBerryButton.interactable = false;
            DataSaveManager.Instance.ActivateBerry();
        }
        else
        {
            notEnoughCoins.SetActive(true);
            BuyBerryButton.interactable = true;
        }
    }
}
