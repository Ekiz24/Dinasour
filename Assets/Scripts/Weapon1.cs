using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon1 : MonoBehaviour
{
    public float shootingInterval;
    public GameObject bulletPrefab;
    public Transform playerPosition;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.parent;//which is the transform of Player object
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != 0)
        {
            timer -= Time.deltaTime;//strat to count time
            if (timer <= 0)
            {
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer==0)
            {
                
                timer = shootingInterval;
                Shoot();
            }
        }
    }

    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, playerPosition.position, Quaternion.identity);// creat a new bullet
        bullet.GetComponent<Bullet>().SetSpeed();// the direction of this bullet
    }
}
