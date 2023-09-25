using System;
using Sources.InputSystem;
using UnityEngine;

namespace Sources.Views
{
    internal sealed class CameraView : MonoBehaviour
    {
        [SerializeField] private float _minYRotation;
        [SerializeField] private float _maxYRotation;

        private IInput _input;
        private float _currentYRotation;
        
        [field: SerializeField] public float MouseSensitivity { get; private set; }
        
        private void Update()
        {
            if (_input == null)
                return;

            var mouseY = _input.MouseY;
        
            mouseY *= MouseSensitivity;
        
            _currentYRotation += mouseY;
            _currentYRotation = Mathf.Clamp(_currentYRotation, _minYRotation, _maxYRotation);

            transform.localEulerAngles = Vector3.right * -_currentYRotation;
        }

        public void Init(IInput input)
        {
            _input = input ?? throw new ArgumentNullException();
        }
    }
}