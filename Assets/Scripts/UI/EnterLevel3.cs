using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel3 : MonoBehaviour
{

    // 在按钮点击时调用这个方法
    public void LoadLevel3()
    {
        // 确保下一个场景名称不为空
        if (!string.IsNullOrEmpty("Level3"))
        {
            DataSaveManager.Instance.AddPassedLevel2();
            SceneManager.LoadScene("Level3");
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}
