using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    public DraggableObjectState State;

    public void SetState(DraggableObjectState newState)
    {
        if (IsTransitionAllowed(State, newState))
        {
            State = newState;
        }
        else
        {
            Debug.Log("Переход запрещен");
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
