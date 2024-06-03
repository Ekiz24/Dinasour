using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBestiary : MonoBehaviour
{
    // 在按钮点击时调用这个方法
    public void LoadBestiary()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("Bestiary"))
        {
            SceneManager.LoadScene("Bestiary");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}