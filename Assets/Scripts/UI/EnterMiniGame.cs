using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMiniGame : MonoBehaviour
{
    public void LoadMiniGame()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("MiniGame"))
        {
            SceneManager.LoadScene("MiniGame");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}
