using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 4f;

    Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("cameraFollowSimple script on " + gameObject.name + " must have target!");
        }

        offset = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 dp = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, dp, smoothSpeed * Time.deltaTime);
    }
}