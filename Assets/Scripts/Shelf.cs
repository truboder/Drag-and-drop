using UnityEngine;

public class Shelf : MonoBehaviour
{
    // ���� ��� ������� ������� ��������� �������� �� �����
    [SerializeField] private int _shelfSortingOrder = 1;

    // �����, ������� ����������, ����� ������ ������ ��������� ������ �������� �����
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �������� ��������� DraggableObject � �������, ������� ���������� � ������
        DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

        // ���������, ��� ������ �������� DraggableObject � ��������� � ��������� "Dropped" (�������)
        if (draggableObject != null && draggableObject.State == DraggableObjectState.Dropped)
        {
            // ���� ������� ���������, ��������� ������ �� �����
            PlaceObjectOnShelf(draggableObject, collision.transform.position);
        }
    }

    // ����� ��� ���������� ������� �� �����
    public void PlaceObjectOnShelf(DraggableObject draggableObject, Vector3 dropPosition)
    {
        // ������������� ��������� ������� �� "OnShelf" (�� �����)
        draggableObject.SetState(DraggableObjectState.OnShelf);

        // ������������� ������� ������� �� ����� � �����, ��� �� ����
        draggableObject.transform.position = dropPosition;

        // ������������� ������� ��������� �������, ����� �� ����������� ��������� �� ������ ������ �������
        draggableObject.SetSortingOrder(_shelfSortingOrder);
    }
}
