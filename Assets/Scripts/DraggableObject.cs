using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool IsCaptured { get; private set; }

    public void ChangeStateToCaptured()
    {
        IsCaptured = true;
    }

    public void ChangeStateToUncaptured()
    {
        IsCaptured = false;
    }
}
