using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.MovementSystem
{
    internal sealed class Movement : IMovable
    {
        public Movement(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; }
    }
}