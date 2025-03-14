using System.Collections.Generic;
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
        DraggableObject draggableObject = FindObjectOfType<DraggableObject>();



        _fallers.Add(draggableObject);
    }
}
