using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMapControl : MonoBehaviour
{
    public Button[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        int level1 = DataSaveManager.Instance.GetPassedLevel1();
        int level2 = DataSaveManager.Instance.GetPassedLevel2();
        int level3 = DataSaveManager.Instance.GetPassedLevel3();

        if (level1 <= 0)
        {
            levelButtons[0].interactable = false;
        }
        if (level2 <= 0)
        {
            levelButtons[1].interactable = false;
        }
        if (level3 <= 0)
        {
            levelButtons[2].interactable = false;
        }

    }

}
