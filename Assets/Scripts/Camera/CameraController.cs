using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fabrikademo.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;

        void Update()
        {
            CameraRotationFollow();
            CameraMovementFollow();
        }

        private void CameraRotationFollow()
        {
            _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation, 
                Quaternion.LookRotation(_targetTransform.position - _cameraTransform.position), 
                _cameraSettings.RotationLerpSpeed * Time.deltaTime);
        }

        private void CameraMovementFollow()
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _targetTransform.position +
                _cameraSettings.PositionOffset, _cameraSettings.PositionLerp);

        }


    }
}