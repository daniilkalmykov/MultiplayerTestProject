namespace Sources.InputSystem
{
    public interface IInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        float MouseX { get; }
        float MouseY { get; }
    }
}