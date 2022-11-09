using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _lerpRate;

    public void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, _playerTransform.position, _lerpRate * Time.deltaTime);
    }
}
