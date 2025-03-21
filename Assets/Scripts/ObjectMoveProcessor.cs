using UnityEngine;

public class ObjectMoveProcessor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int _draggingSortingOrder = 10;

    private DraggableObject _selectedObject;
    private int _mousseButtonTrigger = 0;

    public bool HasTarget { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.TryGetComponent(out DraggableObject draggableObject))
            {
                draggableObject.SetState(DraggableObjectState.Captured);
                draggableObject.SetSortingOrder(_draggingSortingOrder);

                HasTarget = true;
                _selectedObject = draggableObject;
            }
        }

        if (Input.GetMouseButton(_mousseButtonTrigger) && _selectedObject != null)
        {
            MoveObjectWithZ(_selectedObject, _camera.ScreenToWorldPoint(Input.mousePosition));
        }

        if (Input.GetMouseButtonUp(_mousseButtonTrigger))
        {
            ReleaseObject();
        }
    }

    private void ReleaseObject()
    {
        if (_selectedObject != null)
        {
            MoveObjectWithZ(_selectedObject, _selectedObject.transform.position);
            _selectedObject.SetSortingOrder(0);
            _selectedObject.SetState(DraggableObjectState.Dropped);
        }

        HasTarget = false;
        _selectedObject = null;
    }

    private void MoveObjectWithZ(DraggableObject draggableObject, Vector3 newPosition)
    {
        float currentZ = draggableObject.transform.position.z;

        newPosition.z = currentZ;
        draggableObject.transform.position = newPosition;
    }
}
