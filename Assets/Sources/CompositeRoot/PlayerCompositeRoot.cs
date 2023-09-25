using Sources.InputSystem;
using Sources.MovementSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerView))]
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        [SerializeField] private float _speed;
        [SerializeField] private CameraView _cameraView;

        private Movement _movement;
        private PCInput _input;
        private PlayerView _playerView;
        private Rigidbody _rigidbody;

        public IInput Input => _input;

        private void Update()
        {
            _input?.Update();
        }

        public override void Compose()
        {
            _playerView = GetComponent<PlayerView>();
            _rigidbody = GetComponent<Rigidbody>();
            
            _input = new PCInput();
            _movement = new Movement(_speed);

            _playerView.Init(_movement, _input, _rigidbody, _cameraView);
        }
    }
}