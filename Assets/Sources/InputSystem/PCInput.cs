using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.InputSystem
{
    internal sealed class PCInput : IInput
    {
        private const string MouseXParameter = "Mouse X";
        private const string MouseYParameter = "Mouse Y";
        private const string HorizontalParameter = "Horizontal";
        private const string VerticalParameter = "Vertical";
        
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }

        public void Update()
        {
            Horizontal = Input.GetAxis(HorizontalParameter);
            Vertical = Input.GetAxis(VerticalParameter);
            MouseX = Input.GetAxis(MouseXParameter);
            MouseY = Input.GetAxis(MouseYParameter);
        }
    }
}