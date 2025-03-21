using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Transform _objectPosition;
    [SerializeField] private int _shelfSortingOrder = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

        if (draggableObject != null && draggableObject.State == DraggableObjectState.Dropped)
        {
            PlaceObjectOnShelf(draggableObject);
        }
    }

    public void PlaceObjectOnShelf(DraggableObject draggableObject)
    {
        Vector3 shelfPlace = new Vector3(_objectPosition.position.x, _objectPosition.position.y, _objectPosition.position.z);

        draggableObject.SetState(DraggableObjectState.OnShelf);

        draggableObject.transform.position = shelfPlace;
        draggableObject.SetSortingOrder(_shelfSortingOrder);
    }
}
