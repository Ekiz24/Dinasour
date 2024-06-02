using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel1 : MonoBehaviour
{

    // 在按钮点击时调用这个方法
    public void LoadScene1()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("Level1"))
        {
            DataSaveManager.Instance.AddPassedLevel1();
            SceneManager.LoadScene("Level1");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}
