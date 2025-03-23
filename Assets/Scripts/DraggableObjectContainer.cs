using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DraggableObjectContainer : MonoBehaviour
{
    // ������ ��� �������� ���� �������� ���� DraggableObject �� �����
    private List<DraggableObject> _draggableObjects = new List<DraggableObject>();

    private void Start()
    {
        // ����� ������ ��� ������ � ���������� ���� DraggableObject �� �����
        AddDraggableObjects();
    }

    // ����� ��� ������ � ���������� ���� �������� ���� DraggableObject �� �����
    private void AddDraggableObjects()
    {
        // ����� ���� �������� ���� DraggableObject �� �����
        DraggableObject[] draggableObjects = FindObjectsOfType<DraggableObject>();

        // ��������, ������� �� �������
        if (draggableObjects.Length == 0)
        {
            // ���� ������� �� �������, ������� �������������� � �������
            Debug.LogWarning("No DraggableObjects found!");
        }

        // ����������� ������ � ������ � ��������� ��� � ���� _draggableObjects
        _draggableObjects = draggableObjects.ToList();
    }

    // ����� ��� ��������� ������ ���� DraggableObject
    public List<DraggableObject> GetDraggableObjects()
    {
        return _draggableObjects;
    }
}
