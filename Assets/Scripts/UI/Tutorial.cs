using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    private void Start()
    {
        bool oldplayer = DataSaveManager.Instance.GetTutorialActivation();
        if (oldplayer==false)
        {
            tutorial.SetActive(true);
        }
        else
        {
            tutorial.SetActive(false);
        }
    }
}
