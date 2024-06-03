using UnityEngine;
using UnityEngine.UI;

public class TextDisappear : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        StartCoroutine(HideAfterDelay());
    }

    private System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 等待两秒钟

        // 渐隐
        for (float t = 1f; t >= 0; t -= Time.deltaTime)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, t);
            yield return null;
        }

        gameObject.SetActive(false); // 取消激活
    }
}
