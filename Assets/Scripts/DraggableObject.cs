using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    public DraggableObjectState State {  get; private set; }
    public DraggableObjectType Type { get; private set; }

    public void SetState(DraggableObjectState newState)
    {
        if (IsTransitionAllowed(State, newState))
        {
            State = newState;
        }
        else
        {
            Debug.Log("Transsion is not allowed");
        }
    }

    public void SetSortingOrder(int order)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sortingOrder = order;
        }
    }

    private bool IsTransitionAllowed(DraggableObjectState currentState, DraggableObjectState newState)
    {
        switch (currentState)
        {
            case DraggableObjectState.Captured:
                return newState == DraggableObjectState.Dropped || newState == DraggableObjectState.OnShelf || newState == DraggableObjectState.OnGround;

            case DraggableObjectState.Dropped:
                return newState == DraggableObjectState.Captured || newState == DraggableObjectState.OnShelf || newState == DraggableObjectState.OnGround;

            case DraggableObjectState.OnShelf:
                return newState == DraggableObjectState.Captured;

            case DraggableObjectState.OnGround:
                return newState == DraggableObjectState.Captured;

            default:
                return false;
        }
    }
}

public enum DraggableObjectState
{
    Captured,
    Dropped,
    OnGround,
    OnShelf
}

public enum DraggableObjectType
{
    Food,
    Clothes,
    Person,
    Default
}
