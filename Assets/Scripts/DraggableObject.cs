using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    public DraggableObjectState State { get; private set; }

    public void SetState(DraggableObjectState state)
    {
        State = state;
    }

    public void SetSortingOrder(int order)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sortingOrder = order;
        }
    }
}

public enum DraggableObjectState
{
    Idle,
    Captured,
    OnShelf,
    Falling
}
