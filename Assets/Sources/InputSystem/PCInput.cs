using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
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