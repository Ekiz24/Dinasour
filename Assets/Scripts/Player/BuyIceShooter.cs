using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyIceShooter: MonoBehaviour
{
    public Button BuyIceButton;
    public GameObject notEnoughCoins;

    private void Start()
    {
        bool activation = DataSaveManager.Instance.GetIceActivation();

        if(activation == true)
        {
            BuyIceButton.interactable = false;
        }
        else
        {
            BuyIceButton.interactable = true;
        }
    }

    public void BuyIce()
    {
        int coins = DataSaveManager.Instance.GetCoins();
        if (coins >= 20)
        {
            for (int i = 0; i < 20; i++)
            {
                DataSaveManager.Instance.MinusCoin();
            }
            BuyIceButton.interactable = false;
            DataSaveManager.Instance.ActivateIce();
        }
        else
        {
            notEnoughCoins.SetActive(true);
            BuyIceButton.interactable = true;
        }
    }
}
