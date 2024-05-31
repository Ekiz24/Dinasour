using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;
    private GameObject target; // 存储需要销毁的目标对象

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // 设置需要销毁的目标对象
    public void SetTarget(GameObject targetObject)
    {
        target = targetObject;
    }

    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0); // 获取动画播放进度

        if (info.normalizedTime >= 1) // 当动画播放完成时
        {
            Debug.Log("Destroy the explosion and target");
            Destroy(gameObject); // 销毁爆炸动画对象

            if (target != null)
            {
                Destroy(target); // 销毁目标对象
            }
        }
    }
}
