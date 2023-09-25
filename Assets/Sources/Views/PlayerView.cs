using System;
using System.Runtime.CompilerServices;
using Sources.InputSystem;
using Sources.MovementSystem;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.Views
{
    internal sealed class PlayerView : MonoBehaviour
    {
        private IMovable _movable;
        private IInput _input;
        private Rigidbody _rigidbody;
        private CameraView _camera;

        private void Update()
        {
            if (_input == null || _movable == null || _camera == null)
                return;

            Move();
            Rotate();
        }

        public void Init(IMovable movable, IInput input, Rigidbody rigidbody, CameraView cameraView)
        {
            _movable = movable ?? throw new ArgumentNullException();
            _input = input ?? throw new ArgumentNullException();
            _rigidbody = rigidbody;
            _camera = cameraView;
        }
        
        private void Move()
        {
            var cameraRelativeMovement = transform.TransformDirection(_input.Horizontal, 0, _input.Vertical);
            var direction = new Vector3(_movable.Speed * cameraRelativeMovement.x, _rigidbody.velocity.y,
                _movable.Speed * cameraRelativeMovement.z);

            _rigidbody.velocity = direction;
        }
        
        private void Rotate()
        {
            transform.Rotate(Vector3.up * (_input.MouseX * _camera.MouseSensitivity));
        }
    }
}