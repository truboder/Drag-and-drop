using System;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 5f;
    [SerializeField] private WorldBounds _worldBounds;
    [SerializeField] private ObjectMoveProcessor _objectDragger;

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

        if (Input.GetMouseButton(_mousseButtonTrigger) && _objectDragger.HasTarget == false)
        {
            Vector3 difference = _dragOrigin - GetMouseWorldPosition();
            transform.position += difference;         

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _worldBounds.BoundsX.Min, _worldBounds.BoundsX.Max),
                Mathf.Clamp(transform.position.y, _worldBounds.BoundsY.Min, _worldBounds.BoundsY.Max),
                transform.position.z);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z -= transform.position.z;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
 
[Serializable]
public struct Range<T> where T : IComparable<T>
{
    [SerializeField] private T _min;
    [SerializeField] private T _max;

    public Range(T min, T max)
    {
        _min = min;
        _max = max;
    }

    public T Min => _min;
    public T Max => _max;

    public bool Contains(T value)
    {
        return value.CompareTo(_min) >= 0 && value.CompareTo(_max) <= 0;
    }
}
