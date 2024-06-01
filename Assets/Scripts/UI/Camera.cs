using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    //what we are following
    public Transform target;

    //zeros out velocity
    Vector3 velocity = Vector3.zero;

    //time to follow target
    public float smoothTime = .15f;

    // camera shake parameters
    public float shakeDuration = 0.2f; // duration of the shake
    public float shakeMagnitude = 0.1f; // magnitude of the shake
    private float shakeElapsedTime = 0f;
    private Vector3 originalPos;

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        targetPos.x += 6;
        targetPos.y += 0;

        //align the camera and the target z position
        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

        // apply shake effect if shaking
        if (shakeElapsedTime > 0)
        {
            transform.localPosition = targetPos + Random.insideUnitSphere * shakeMagnitude;
            shakeElapsedTime -= Time.deltaTime;
        }
    }

    // method to trigger the camera shake
    public void TriggerShake()
    {
        shakeElapsedTime = shakeDuration;
    }
}