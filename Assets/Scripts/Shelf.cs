using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Vector3 _objectPosition;
    [SerializeField] private int _shelfSortingOrder = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

        if (draggableObject != null && draggableObject.State == DraggableObjectState.Falling)
        {
            PlaceObjectOnShelf(draggableObject);
        }
    }

    public void PlaceObjectOnShelf(DraggableObject draggableObject)
    {
        Vector3 shelfPlace = new Vector3(_objectPosition.x, _objectPosition.y, _objectPosition.z);

        draggableObject.SetState(DraggableObjectState.OnShelf);

        draggableObject.transform.position = shelfPlace;
        draggableObject.SetSortingOrder(_shelfSortingOrder);
    }
}
