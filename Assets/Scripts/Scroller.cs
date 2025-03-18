using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 5f;
    [SerializeField] private Vector2 _cameraBoundsX = new Vector2(-10f, 10f);
    [SerializeField] private Vector2 _cameraBoundsY = new Vector2(-5f, 5f);

    [SerializeField] private ObjectDragger _objectDragger;

    private Vector3 _dragOrigin;
    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        HandleScrolling();
    }

    private void HandleScrolling()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            _dragOrigin = GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(_mousseButtonTrigger) && _objectDragger.IsThereTarget == false)
        {
            Vector3 difference = _dragOrigin - GetMouseWorldPosition();
            transform.position += difference;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _cameraBoundsX.x, _cameraBoundsX.y), Mathf.Clamp(transform.position.y, _cameraBoundsY.x, _cameraBoundsY.y), transform.position.z
            );
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z -= transform.position.z;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
