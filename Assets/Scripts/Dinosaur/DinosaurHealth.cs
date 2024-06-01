using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurHealth : MonoBehaviour
{
    public int maxHealth = 12; // 敌人最大血量
    private int currentHealth; // 当前血量
    private Camera cameraShake;

    public GameObject webExplosionPrefab;
    public GameObject snowballExplosionPrefab;
    public GameObject berrybombExplosionPrefab;

    public int CurrentHealth // 添加一个公开的属性来获取当前血量
    {
        get { return currentHealth; }
    }

    void Start()
    {
        currentHealth = maxHealth; // 初始化当前血量
        cameraShake = FindObjectOfType<Camera>(); // 查找相机抖动脚本
        if (cameraShake != null) cameraShake.TriggerShake();
        Debug.Log("Start: Current Health = " + currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: Collided with " + collision.gameObject.tag);

        if (collision.CompareTag("Web"))
        {
            Debug.Log("Collided with Web");
            TakeDamage(4, "web");
            if (cameraShake != null) cameraShake.TriggerShake();
            Destroy(collision.gameObject); // 碰撞后摧毁子弹
        }
        else if (collision.CompareTag("Snowball"))
        {
            Debug.Log("Collided with Snowball");
            TakeDamage(3, "snowball");
            if (cameraShake != null) cameraShake.TriggerShake();
            Destroy(collision.gameObject); // 碰撞后摧毁子弹
        }
        else if (collision.CompareTag("Berrybomb"))
        {
            Debug.Log("Collided with Berrybomb");
            TakeDamage(2, "berrybomb");
            if (cameraShake != null) cameraShake.TriggerShake();
            Destroy(collision.gameObject); // 碰撞后摧毁子弹
        }
    }

    // 处理敌人受到的伤害
    void TakeDamage(int damage, string explosionType)
    {
        currentHealth -= damage;
        Debug.Log("TakeDamage: Current Health = " + currentHealth);

        if (currentHealth <= 0)
        {
            Explode(explosionType);
        }
    }

    // 播放爆炸动画并摧毁敌人对象
    void Explode(string explosionType)
    {
        Debug.Log("Explode: Triggering explosion " + explosionType);
        GameObject explosionPrefab = null;

        switch (explosionType)
        {
            case "web":
                explosionPrefab = webExplosionPrefab;
                break;
            case "snowball":
                explosionPrefab = snowballExplosionPrefab;
                break;
            case "berrybomb":
                explosionPrefab = berrybombExplosionPrefab;
                break;
        }

        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Explosion explosionScript = explosion.GetComponent<Explosion>();
            if (explosionScript != null)
            {
                explosionScript.SetTarget(gameObject); // 设置爆炸的目标为当前敌人对象
            }
        }
    }
}
