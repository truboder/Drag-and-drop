using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    [SerializeField] private Camera _m_Camera;

    private Collider2D _selectedObject;
    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            Ray ray = _m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                _selectedObject = hit.collider;
            }
        }

        if (Input.GetMouseButton(_mousseButtonTrigger) && _selectedObject != null)
        {
            Vector2 mousePosition = _m_Camera.ScreenToWorldPoint(Input.mousePosition);
            _selectedObject.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }

        if (Input.GetMouseButtonUp(_mousseButtonTrigger))
        {
            _selectedObject = null;
        }
    }
}
