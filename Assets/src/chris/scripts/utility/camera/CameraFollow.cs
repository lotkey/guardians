using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 difference;
    public Transform target;

    void FixedUpdate()
    {
        difference = Input.mousePosition - target.transform.position;
        difference = difference.normalized;
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10) + new Vector3(difference.x, difference.y, 0);
    }
}