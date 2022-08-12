using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 14f;

    void Update()
    {
        if (!GameManager.isGameStarted)
            return;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 rotation = Input.GetTouch(0).deltaPosition;
            transform.Rotate(0,-rotation.x * _speed * Time.deltaTime, 0);
        }
    }
}
