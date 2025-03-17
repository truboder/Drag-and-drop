using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public DraggableObjectState State { get; private set; }

    public void SetState(DraggableObjectState state)
    {
        State = state;
    }
}

public enum DraggableObjectState
{
    Idle,
    Captured,
    OnShelf,
    Falling
}
