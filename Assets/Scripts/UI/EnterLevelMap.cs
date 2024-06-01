using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevelMap : MonoBehaviour
{

    // 在按钮点击时调用这个方法
    public void LoadLevelMap()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("LevelMap"))
        {
            SceneManager.LoadScene("LevelMap");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}
