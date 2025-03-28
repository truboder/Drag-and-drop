using UnityEngine;

public class CharacterItemInteractionSystem : MonoBehaviour
{
    [SerializeField] private Transform _mouthPoint;
    [SerializeField] private Transform _rightHandPoint;
    [SerializeField] private Transform _leftHandPoint;
    [SerializeField] private float _mouthInteractionRadius;

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

    //    if (draggableObject != null && draggableObject.Type == DraggableObjectType.Food)
    //    {

    //    }
    //}

    private void Update()
    {
        CheckFoodInMouthArea();
    }

    private void CheckFoodInMouthArea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_mouthPoint.position, _mouthInteractionRadius);

        foreach (Collider2D collider in colliders)
        {
            TryConsumeFood(collider);
        }
    }

    private void TryConsumeFood(Collider2D collider)
    {
        DraggableObject draggableObject = collider.GetComponent<DraggableObject>();

        if (draggableObject == null)
        {
            return;
        }

        if (draggableObject.Type == DraggableObjectType.Food && draggableObject.State == DraggableObjectState.Dropped)
        {
            ConsumeFood(draggableObject);
        }
    }

    private void ConsumeFood(DraggableObject foodDraggableObject)
    {
        Destroy(foodDraggableObject);
    }
}
