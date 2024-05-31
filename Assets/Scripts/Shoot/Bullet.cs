using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    //public GameObject explosionPrefab; //for playing explosion animation
    //public Transform playerPosition;

    new private Rigidbody2D rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    public void SetSpeed()//the speed of bullets
    {
        rigidbody.velocity = Vector2.right * speed; //the direction of bullets
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dinosaur")|| collision.CompareTag("Walls"))
        {
            Debug.Log("Collided!");
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject); // destroy that bullet

        }
    }
}
