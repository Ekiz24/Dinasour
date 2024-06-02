using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMainMenu : MonoBehaviour
{

    // 在按钮点击时调用这个方法
    public void LoadMainMenu()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}