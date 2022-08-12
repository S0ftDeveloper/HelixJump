using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smooth = 0.04f;
     void Start()
    {
        offset = transform.position - target.position;
    }
     void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smooth);
        transform.position = newPosition;
    }
}