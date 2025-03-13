using Unity.VisualScripting;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _groundPoint;
    [SerializeField] private float _gravityForce = 2f;
    [SerializeField] private float _maxAllowedY =3f;


    private Collider2D _selectedObject;

    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        HandleDragging();
        ApplyGravity();
    }

    private void HandleDragging()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                _selectedObject = hit.collider;
            }
        }

        if (Input.GetMouseButton(_mousseButtonTrigger) && _selectedObject != null)
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _selectedObject.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }

        if (Input.GetMouseButtonUp(_mousseButtonTrigger))
        {
            if (_selectedObject != null)
            {
                Vector3 position = _selectedObject.transform.position;

                if (position.y > _maxAllowedY)
                {
                    position.y = _maxAllowedY;
                }

                _selectedObject.transform.position = position;

                _selectedObject = null;
            }
        }
    }

    private void ApplyGravity()
    {
        Collider2D[] objects = FindObjectsOfType<Collider2D>();

        foreach (Collider2D obj in objects)
        {
            if (obj == _selectedObject)
            {
                continue;
            }

            Vector3 position = obj.transform.position;

            if (position.y > _groundPoint)
            {
                position.y -= _gravityForce * Time.deltaTime;
                obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, _groundPoint), position.z);
            }
        }
    }
}
