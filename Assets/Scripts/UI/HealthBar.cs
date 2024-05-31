using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // 用来显示血条的UI Image
    public DinosaurHealth dinosaurHealth; // 引用到敌人的血量脚本
    public float smoothSpeed = 0.1f; // 调整这个值来改变血条变化的速度

    private float targetFillAmount;

    void Start()
    {
        if (healthBarImage == null)
        {
            healthBarImage = GetComponent<Image>();
        }
    }

    void Update()
    {
        if (dinosaurHealth != null)
        {
            // 计算目标填充量
            targetFillAmount = (float)dinosaurHealth.CurrentHealth / dinosaurHealth.maxHealth;

            // 使用Lerp函数让填充量平滑过渡到目标值
            healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, targetFillAmount, smoothSpeed * Time.deltaTime);
        }
    }
}
