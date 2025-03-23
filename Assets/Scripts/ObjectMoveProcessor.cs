using UnityEngine;

public class ObjectMoveProcessor : MonoBehaviour
{
    // Ссылка на камеру, которая используется для преобразования координат мыши в мировые координаты
    [SerializeField] private Camera _camera;
    // Порядок отрисовки объекта, когда он перетаскивается (чтобы он отображался поверх других объектов)
    [SerializeField] private int _draggingSortingOrder = 10;

    // Текущий выбранный объект, который перетаскивается
    private DraggableObject _selectedObject;

    // Кнопка мыши, которая активирует перетаскивание (0 - левая кнопка мыши)
    private int _mousseButtonTrigger = 0;

    // Свойство, указывающее, есть ли в данный момент выбранный объект для перетаскивания
    public bool HasTarget { get; private set; }

    private void Update()
    {
        // Если нажата кнопка мыши, пытаемся выбрать объект для перетаскивания
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            // Создаем луч из позиции мыши в мировые координаты
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            // Проверяем пересечение луча с 2D-коллайдерами
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            // Если луч пересекается с объектом, который можно перетаскивать
            if (hit.TryGetComponent(out DraggableObject draggableObject))
            {
                // Устанавливаем состояние объекта "Captured" (захвачен)
                draggableObject.SetState(DraggableObjectState.Captured);

                // Устанавливаем порядок отрисовки объекта, чтобы он отображался поверх других объектов
                draggableObject.SetSortingOrder(_draggingSortingOrder);

                // Указываем, что объект выбран для перетаскивания
                HasTarget = true;
                _selectedObject = draggableObject;
            }
        }

        // Если кнопка мыши удерживается и есть выбранный объект, перемещаем его
        if (Input.GetMouseButton(_mousseButtonTrigger) && _selectedObject != null)
        {
            // Перемещаем объект в позицию мыши с учетом Z-координаты
            MoveObjectWithZ(_selectedObject, _camera.ScreenToWorldPoint(Input.mousePosition));
        }

        // Если кнопка мыши отпущена, освобождаем объект
        if (Input.GetMouseButtonUp(_mousseButtonTrigger))
        {
            ReleaseObject();
        }
    }

    // Метод для освобождения объекта
    private void ReleaseObject()
    {
        if (_selectedObject != null)
        {
            // Устанавливаем позицию объекта (с учетом Z-координаты)
            MoveObjectWithZ(_selectedObject, _selectedObject.transform.position);

            // Возвращаем порядок отрисовки объекта в исходное состояние
            _selectedObject.SetSortingOrder(0);

            // Устанавливаем состояние объекта "Dropped" (отпущен)
            _selectedObject.SetState(DraggableObjectState.Dropped);
        }

        // Сбрасываем флаг наличия выбранного объекта
        HasTarget = false;
        _selectedObject = null;
    }

    // Метод для перемещения объекта с учетом Z-координаты
    private void MoveObjectWithZ(DraggableObject draggableObject, Vector3 newPosition)
    {
        // Сохраняем текущую Z-координату объекта
        float currentZ = draggableObject.transform.position.z;

        // Устанавливаем новую позицию объекта, сохраняя Z-координату
        newPosition.z = currentZ;
        draggableObject.transform.position = newPosition;
    }
}
