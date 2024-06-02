using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    // 引用要激活/禁用的面板
    public GameObject panel;

    // 当需要激活面板时调用的方法
    public void ActivatePanel()
    {
        if (panel != null)
        {
            
            panel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Panel reference is not set.");
        }
    }

    // 当需要禁用面板时调用的方法
    public void DeactivatePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel reference is not set.");
        }
    }
}
