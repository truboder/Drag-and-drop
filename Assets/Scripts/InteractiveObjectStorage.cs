using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractiveObjectStorage : MonoBehaviour
{
    private List<DraggableObject> _fallers = new List<DraggableObject>();

    private void Start()
    {
        AddDraggableObjects();
    }

    private void AddDraggableObjects()
    {
        DraggableObject[] draggableObjects = FindObjectsOfType<DraggableObject>();

        if (draggableObjects.Length == 0)
        {
            Debug.LogWarning("No DraggableObjects found!");
        }

        _fallers = draggableObjects.ToList();
    }

    public List<DraggableObject> GetFallers()
    {
        return _fallers;
    }
}
