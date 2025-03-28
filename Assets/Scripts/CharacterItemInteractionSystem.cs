using UnityEngine;

public class CharacterItemInteractionSystem : MonoBehaviour
{
    [SerializeField] private Transform _mouthPoimt;
    [SerializeField] private Transform _rightHandPoint;
    [SerializeField] private Transform _leftHandPoint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

        if (draggableObject != null && draggableObject.T)
    }
}
