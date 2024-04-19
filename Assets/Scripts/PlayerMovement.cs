using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private float speed = 10.9f;
   

    private void Awake()
    {
      
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //When player press left or right
        if (horizontal != 0)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", 0);
        }
        //When player press up or down
        if (vertical != 0)
        {
            animator.SetFloat("Vertical", vertical);
            animator.SetFloat("Horizontal", 0);
        }
        //the player changes stand to move
        Vector2 direction = new Vector2(horizontal, vertical);
        animator.SetFloat("Speed", direction.magnitude);

        //move character to the direction
        rigidbody2d.velocity = direction * speed;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -32f, 32f), Mathf.Clamp(transform.localPosition.y, -32f, 32f), 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
    }

}
