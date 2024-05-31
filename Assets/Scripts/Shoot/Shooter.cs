using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : Gun
{

    protected override void Shoot()
    {
        Debug.Log("Shoot!");
        GameObject Bullet = Instantiate(BulletPrefab, playerPosition.position, Quaternion.identity);// creat a new bullet

        Bullet.GetComponent<Bullet>().SetSpeed();// the direction of this bullet
    }
}
