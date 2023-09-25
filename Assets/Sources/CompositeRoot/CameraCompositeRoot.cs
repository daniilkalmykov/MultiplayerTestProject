using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(CameraView))]
    internal sealed class CameraCompositeRoot : CompositeRoot
    {
        [SerializeField] private PlayerCompositeRoot _playerCompositeRoot;
        
        private CameraView _cameraView;

        public override void Compose()
        {
            _cameraView = GetComponent<CameraView>();

            _cameraView.Init(_playerCompositeRoot.Input);
        }
    }
}