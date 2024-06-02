using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryShooter : Gun
{
    public float spreadAngle = 15f; // 每个子弹的发射角度间隔

    protected override void Shoot()
    {
        Debug.Log("Shoot!");

        // 中间子弹
        CreateBullet(Vector2.right);

        // 向上偏移的子弹
        CreateBullet(Quaternion.Euler(0, 0, spreadAngle) * Vector2.right);

        // 向下偏移的子弹
        CreateBullet(Quaternion.Euler(0, 0, -spreadAngle) * Vector2.right);

        // 更向上偏移的子弹
        CreateBullet(Quaternion.Euler(0, 0, 2 * spreadAngle) * Vector2.right);

        // 更向下偏移的子弹
        CreateBullet(Quaternion.Euler(0, 0, -2 * spreadAngle) * Vector2.right);
    }

    private void CreateBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(BulletPrefab, playerPosition.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetSpeed(direction); // 设置子弹的方向和速度
    }
}
