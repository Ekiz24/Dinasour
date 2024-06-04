using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velociraptor : DinosaurHealth
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: Collided with " + collision.gameObject.tag);

        if (collision.CompareTag("Web"))
        {
            Debug.Log("Collided with Web");
            TakeDamage(6, "web");
            if (cameraShake != null) cameraShake.TriggerShake();
            Destroy(collision.gameObject); // 碰撞后摧毁子弹

        }
        else if (collision.CompareTag("Snowball"))
        {
            Debug.Log("Collided with Snowball");
            TakeDamage(2, "snowball");
            if (cameraShake != null) cameraShake.TriggerShake();
            Destroy(collision.gameObject); // 碰撞后摧毁子弹
        }
        else if (collision.CompareTag("Berrybomb"))
        {
            Debug.Log("Collided with Berrybomb");
            TakeDamage(1, "berrybomb");
            if (cameraShake != null) cameraShake.TriggerShake();
            Destroy(collision.gameObject); // 碰撞后摧毁子弹
        }
    }
}