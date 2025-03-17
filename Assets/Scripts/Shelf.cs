using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Vector3 _objectPosition;

    public void PlaceObjectOnShelf(DraggableObject draggableObject)
    {
        Vector3 shelfPlace = new Vector3(_objectPosition.x, _objectPosition.y, _objectPosition.z);

        draggableObject.SetState(DraggableObjectState.OnShelf);

        draggableObject.transform.position = shelfPlace;
    }
}
