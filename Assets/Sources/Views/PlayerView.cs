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
        private readonly int _speed = Animator.StringToHash("Speed");
        
        private IMovable _movable;
        private IInput _input;
        private Rigidbody _rigidbody;
        private CameraView _camera;
        private Animator _animator;

        private void Update()
        {
            if (_input == null || _movable == null)
                return;

            _animator.SetFloat(_speed, _rigidbody.velocity.magnitude);
            
            Move();
            Rotate();
        }

        public void Init(IMovable movable, IInput input, Rigidbody rigidbody, CameraView cameraView, Animator animator)
        {
            _movable = movable ?? throw new ArgumentNullException();
            _input = input ?? throw new ArgumentNullException();
            _rigidbody = rigidbody;
            _camera = cameraView;
            _animator = animator;
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