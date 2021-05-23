using UnityEngine.Events;

public interface IInputManager
{
    UnityVector3Event OnHit { get; }
}