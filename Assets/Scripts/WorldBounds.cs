using UnityEngine;

// �������, ������� ��������� ��������� ������� ����� ������ ����� ���� �������� ������� � Unity
[CreateAssetMenu(fileName = "WorldBounds", menuName = "ScriptableObjects/WorldBounds", order = 1)]
public class WorldBounds : ScriptableObject
{
    // ���� ��� �������� ��������� �� ��� X
    [SerializeField] private Range<float> _boundsX;
    // ���� ��� �������� ��������� �� ��� Y
    [SerializeField] private Range<float> _boundsY;

    // �������� ��� ��������� ��������� �� ��� X
    public Range<float> BoundsX => _boundsX;
    // �������� ��� ��������� ��������� �� ��� Y
    public Range<float> BoundsY => _boundsY;
}