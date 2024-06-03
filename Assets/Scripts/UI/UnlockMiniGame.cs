using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMiniGame : MonoBehaviour
{
    public void PassedLevel3()
    {
        DataSaveManager.Instance.AddPassedLevel3();
    }

}
