using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fabrikademo.PlayerInput;
using fabrikademo.PlayerMovement;


public class WheelRotation : MonoBehaviour
{
    [SerializeField] private float _maxWheelAngle = 45;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private InputData _inputData;
    private float _rotateSpeed;

    private void Awake()
        {
            _rotateSpeed = FindObjectOfType<PlayerMovementController>().RotateSpeed;
        }

    void FixedUpdate()
    {
        SteeringWheelRotate();

    }

    private void SteeringWheelRotate()
    {
        transform.localEulerAngles = Vector3.back * Mathf.Clamp((_inputData.Horizontal * _rotateSpeed), -_maxWheelAngle, _maxWheelAngle);
    }
}
