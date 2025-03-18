using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxAllowedY = 4f;
    [SerializeField] private int _draggingSortingOrder = 10;

    private DraggableObject _selectedObject;

    public bool IsThereTarget { get; private set; }

    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        HandleDragging();
    }

    public void HandleDragging()
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
                    _selectedObject.SetState(DraggableObjectState.Captured);
                    IsThereTarget = true;
                    _selectedObject.SetSortingOrder(_draggingSortingOrder);
                }
            }
        }

        if (Input.GetMouseButton(_mousseButtonTrigger) && _selectedObject != null)
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _selectedObject.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(_mousseButtonTrigger))
        {
            Vector3 position = _selectedObject.transform.position;

            if (_selectedObject.transform.position.y > _maxAllowedY)
            {
                position.y = _maxAllowedY;
            }

            _selectedObject.transform.position = position;
            _selectedObject.SetState(DraggableObjectState.Idle);
            _selectedObject.SetSortingOrder(0);

            IsThereTarget = false;
            _selectedObject = null;
        }
    }
}
