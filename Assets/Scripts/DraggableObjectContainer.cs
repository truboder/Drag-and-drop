using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DraggableObjectContainer : MonoBehaviour
{
    public static DraggableObjectContainer Singleton { get; private set; }

    private List<DraggableObject> _draggableObjects = new List<DraggableObject>();

    private void Awake()
    {
        Singleton = this;
    }

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

        _draggableObjects = draggableObjects.ToList();
    }

    public List<DraggableObject> GetDraggableObjects()
    {
        return _draggableObjects;
    }
}
