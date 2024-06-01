using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel2 : MonoBehaviour
{

    // 在按钮点击时调用这个方法
    public void LoadLevel2()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("Level2"))
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}
