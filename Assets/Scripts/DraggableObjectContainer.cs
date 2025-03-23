using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DraggableObjectContainer : MonoBehaviour
{
    // Список для хранения всех объектов типа DraggableObject на сцене
    private List<DraggableObject> _draggableObjects = new List<DraggableObject>();

    private void Start()
    {
        // Вызов метода для поиска и добавления всех DraggableObject на сцене
        AddDraggableObjects();
    }

    // Метод для поиска и добавления всех объектов типа DraggableObject на сцене
    private void AddDraggableObjects()
    {
        // Поиск всех объектов типа DraggableObject на сцене
        DraggableObject[] draggableObjects = FindObjectsOfType<DraggableObject>();

        // Проверка, найдены ли объекты
        if (draggableObjects.Length == 0)
        {
            // Если объекты не найдены, выводим предупреждение в консоль
            Debug.LogWarning("No DraggableObjects found!");
        }

        // Преобразуем массив в список и сохраняем его в поле _draggableObjects
        _draggableObjects = draggableObjects.ToList();
    }

    // Метод для получения списка всех DraggableObject
    public List<DraggableObject> GetDraggableObjects()
    {
        return _draggableObjects;
    }
}
