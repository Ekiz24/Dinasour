using UnityEngine;
using UnityEngine.UI;

public class CheatCode : MonoBehaviour
{
    public InputField inputField;
    public GameObject[] panels;

    void Start()
    {
        // 添加监听器，监听InputField的onEndEdit事件
        inputField.onEndEdit.AddListener(CheckInput);
    }

    void CheckInput(string userInput)
    {
        // 检查用户输入是否为 "XXX"
        if (userInput == "Zike Tang"|| userInput == "ZikeTang"
            || userInput == "Aleksander Viks" || userInput == "AleksanderViks"
            || userInput == "Ilayda Gümüs" || userInput == "IlaydaGümüs"
            || userInput == "Ilayda Gumus" || userInput == "IlaydaGumus")
        {
            // 如果输入为 "AAA"，执行特定代码
            ExecuteSpecialCode();
        }
    }

    void ExecuteSpecialCode()
    {
        // 您希望执行的代码
        Debug.Log("Cheat Code Correct!");
        for (int i = 0; i < 99; i++)
        {
            DataSaveManager.Instance.AddCoin();
        }
        DataSaveManager.Instance.AddPassedLevel1();
        DataSaveManager.Instance.AddPassedLevel2();
        DataSaveManager.Instance.AddPassedLevel3();
        panels[0].SetActive(false);
        panels[1].SetActive(true);
    }
}
