using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool IsCaptured { get; private set; }

    public bool IsOnShelf { get; private set; }

    public void ChangeStateOnShelf()
    {
        IsOnShelf = true;
    }

    public void ChangeStateOffShelf()
    {
        IsOnShelf = false;
    }

    public void ChangeStateToCaptured()
    {
        IsCaptured = true;
    }

    public void ChangeStateToUncaptured()
    {
        IsCaptured = false;
    }

    public void PlaceOnShelf(Vector3 shelfPosition)
    {
        IsOnShelf = true;
        transform.position = shelfPosition;
    }
}
