using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    //public GameObject explosionPrefab; //for playing explosion animation
    //public Transform playerPosition;
    public float bulletTime = 2f;

    new private Rigidbody2D rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        // 设置子弹的速度
        //SetSpeed();

        // 在lifetime秒后销毁子弹
        Destroy(gameObject, bulletTime);
    }

    public void SetSpeed(Vector2 direction)//the speed of bullets
    {
        //rigidbody.velocity = Vector2.right * speed; //the direction of bullets
        rigidbody.velocity = direction.normalized * speed; // 设置子弹的速度和方向
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dinosaur")|| collision.CompareTag("Walls"))
        {
            Debug.Log("Collided!");
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject); // destroy that bullet

        }
    }
}
