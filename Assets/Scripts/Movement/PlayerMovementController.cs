using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fabrikademo.PlayerInput;

namespace fabrikademo.PlayerMovement
{

    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _motorForce = 1000f;
        [SerializeField] private float _rotateSpeed = 1000f;
        public float RotateSpeed { get { return _rotateSpeed; } } // Refactor this into scriptible object
        [SerializeField] private float _maxSpeed = 5f;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputData _inputData;

        private void FixedUpdate()
        {
            Accelerate();
            RotateCar();
        }

        private void RotateCar()
        {
            _rigidbody.rotation = _rigidbody.rotation * Quaternion.Euler(Vector3.up * _inputData.Horizontal * _rotateSpeed * Time.deltaTime);
        }

        private void Accelerate()
        {
            if (_rigidbody.velocity.magnitude <= _maxSpeed)
            {
                _rigidbody.AddForce(_rigidbody.transform.forward * _inputData.Vertical * _motorForce * Time.deltaTime, ForceMode.Force);
            }

        }



    }
}