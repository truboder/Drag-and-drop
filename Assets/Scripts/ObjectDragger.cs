using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private DraggableObject _selectedObject;

    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        HandleDragging();
    }

    private void HandleDragging()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                DraggableObject draggableObject = hit.collider.GetComponent<DraggableObject>();

                if (draggableObject != null)
                {
                    _selectedObject = draggableObject;
                }

            }
        }

        if (Input.GetMouseButton(_mousseButtonTrigger) && _selectedObject != null)
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _selectedObject.Move(mousePosition);
        }

        if (Input.GetMouseButtonUp(_mousseButtonTrigger))
        {
            _selectedObject.Release();
            _selectedObject = null;
        }
    }
}
