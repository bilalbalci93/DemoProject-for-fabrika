using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fabrikademo.PlayerInput;

namespace fabrikademo.PlayerMovement
{

    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputData _inputData;

        private void Update()
        {
            _rigidbody.MovePosition(_rigidbody.transform.forward * _inputData.Vertical);
            _rigidbody.MovePosition(_rigidbody.transform.right * _inputData.Horizontal);
        }
    }
}