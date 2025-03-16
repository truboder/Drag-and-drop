using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Vector3 _objectPosition;

    private int _mousseButtonTrigger = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

        if (draggableObject != null && !draggableObject.IsOnShelf)
        {
            if (Input.GetMouseButtonUp(_mousseButtonTrigger))
            {
                draggableObject.PlaceOnShelf(_objectPosition);
            }
        }
    }
}
