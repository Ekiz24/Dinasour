using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShooter : Gun
{
    public int numberOfBullets = 3; // 要生成的子弹数量
    public float delayBetweenShots = 0.5f; // 每次发射之间的延迟

    protected override void Shoot()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            Debug.Log("Shoot!");
            GameObject bullet = Instantiate(BulletPrefab, playerPosition.position, Quaternion.identity); // 创建新的子弹

            bullet.GetComponent<Bullet>().SetSpeed(Vector2.right); // 设置子弹的方向和速度

            yield return new WaitForSeconds(delayBetweenShots); // 等待一段时间再发射下一颗子弹
        }
    }
}
