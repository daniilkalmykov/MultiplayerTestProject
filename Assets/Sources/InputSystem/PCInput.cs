using UnityEngine;

namespace Sources.InputSystem
{
    internal sealed class PCInput : IInput
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public void Update()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }
    }
}