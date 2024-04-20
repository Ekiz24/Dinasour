using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo info;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);//get the process of animation playing
        if (info.normalizedTime >= 1) //when playing is done
        {
            Destroy(gameObject);//destroy the explosion animation
        }
    }
}
