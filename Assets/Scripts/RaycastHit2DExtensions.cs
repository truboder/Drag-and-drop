using UnityEngine;

// ����������� ����� ��� ���������� ���������������� RaycastHit2D
public static class RaycastHit2DExtensions
{
    // ����� ���������� ��� RaycastHit2D, ������� �������� �������� ��������� ���� T
    public static bool TryGetComponent<T>(this RaycastHit2D hit, out T component) where T : Component
    {
        // ���������, ���� �� ��������� � �������, � ������� ��������� ������������
        if (hit.collider == null)
        {
            // ���� ���������� ���, ���������� null � false
            component = null;
            return false;
        }

        // �������� �������� ��������� ���� T � ����������
        component = hit.collider.GetComponent<T>();

        // ���������� true, ���� ��������� ��� ������, ����� false
        return component != null;
    }
}
