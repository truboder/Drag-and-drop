using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    // �������� ��������� ������
    [SerializeField] private float _scrollSpeed = 5f;
    // ������� ����, � �������� ������� ����� ������������ ������
    [SerializeField] private WorldBounds _worldBounds;
    // ��������� ����������� ��������, ������� ���������, ��������� �� DraggableObject � �������
    [SerializeField] private ObjectMoveProcessor _objectMoveProcessor;

    // ��������� �����, ������ �������� �������������� ������
    private Vector3 _dragOrigin;
    // ������ ����, ������� ���������� �������������� ������ (0 - ����� ������ ����)
    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        // ��������� ��������� ������ ������ ����
        HandleScrolling();
    }

    // ����� ��� ��������� ��������� ������
    private void HandleScrolling()
    {
        // ���� ������ ������ ����, ���������� ��������� ������� ��������������
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            _dragOrigin = GetMouseWorldPosition();
        }

        // ���� ������ ���� ������������ � ��� ��������� ����������� �������
        if (Input.GetMouseButton(_mousseButtonTrigger) && _objectMoveProcessor.HasTarget == false)
        {
            // ��������� ������� ����� ������� �������� ���� � ��������� ������ ��������������
            Vector3 difference = _dragOrigin - GetMouseWorldPosition();
            // ���������� ������ �� ��� �������
            transform.position += difference;

            // ������������ ������� ������ � �������� ������ ����
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _worldBounds.BoundsX.Min, _worldBounds.BoundsX.Max),
                Mathf.Clamp(transform.position.y, _worldBounds.BoundsY.Min, _worldBounds.BoundsY.Max),
                transform.position.z);
        }
    }

    // ����� ��� ��������� ������� ���� � ������� �����������
    private Vector3 GetMouseWorldPosition()
    {
        // �������� ������� ���� �� ������
        Vector3 mousePosition = Input.mousePosition;

        // ������������ Z-����������, ����� ������ ������� ������
        mousePosition.z -= transform.position.z;

        // ����������� �������� ���������� � �������
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
