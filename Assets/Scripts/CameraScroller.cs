using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    // Скорость прокрутки камеры
    [SerializeField] private float _scrollSpeed = 5f;
    // Границы мира, в пределах которых может перемещаться камера
    [SerializeField] private WorldBounds _worldBounds;
    // Процессор перемещения объектов, который проверяет, находится ли DraggableObject в захвате
    [SerializeField] private ObjectMoveProcessor _objectMoveProcessor;

    // Начальная точка, откуда началось перетаскивание камеры
    private Vector3 _dragOrigin;
    // Кнопка мыши, которая активирует перетаскивание камеры (0 - левая кнопка мыши)
    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        // Обработка прокрутки камеры каждый кадр
        HandleScrolling();
    }

    // Метод для обработки прокрутки камеры
    private void HandleScrolling()
    {
        // Если нажата кнопка мыши, запоминаем начальную позицию перетаскивания
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            _dragOrigin = GetMouseWorldPosition();
        }

        // Если кнопка мыши удерживается и нет активного перемещения объекта
        if (Input.GetMouseButton(_mousseButtonTrigger) && _objectMoveProcessor.HasTarget == false)
        {
            // Вычисляем разницу между текущей позицией мыши и начальной точкой перетаскивания
            Vector3 difference = _dragOrigin - GetMouseWorldPosition();
            // Перемещаем камеру на эту разницу
            transform.position += difference;

            // Ограничиваем позицию камеры в пределах границ мира
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _worldBounds.BoundsX.Min, _worldBounds.BoundsX.Max),
                Mathf.Clamp(transform.position.y, _worldBounds.BoundsY.Min, _worldBounds.BoundsY.Max),
                transform.position.z);
        }
    }

    // Метод для получения позиции мыши в мировых координатах
    private Vector3 GetMouseWorldPosition()
    {
        // Получаем позицию мыши на экране
        Vector3 mousePosition = Input.mousePosition;

        // Корректируем Z-координату, чтобы учесть позицию камеры
        mousePosition.z -= transform.position.z;

        // Преобразуем экранные координаты в мировые
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
