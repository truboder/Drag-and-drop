using UnityEngine;

public class Shelf : MonoBehaviour
{
    // Поле для задания порядка отрисовки объектов на полке
    [SerializeField] private int _shelfSortingOrder = 1;

    // Метод, который вызывается, когда другой объект находится внутри триггера полки
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Получаем компонент DraggableObject у объекта, который столкнулся с полкой
        DraggableObject draggableObject = collision.GetComponent<DraggableObject>();

        // Проверяем, что объект является DraggableObject и находится в состоянии "Dropped" (отпущен)
        if (draggableObject != null && draggableObject.State == DraggableObjectState.Dropped)
        {
            // Если условия выполнены, размещаем объект на полке
            PlaceObjectOnShelf(draggableObject, collision.transform.position);
        }
    }

    // Метод для размещения объекта на полке
    public void PlaceObjectOnShelf(DraggableObject draggableObject, Vector3 dropPosition)
    {
        // Устанавливаем состояние объекта на "OnShelf" (на полке)
        draggableObject.SetState(DraggableObjectState.OnShelf);

        // Устанавливаем позицию объекта на полке в точку, где он упал
        draggableObject.transform.position = dropPosition;

        // Устанавливаем порядок отрисовки объекта, чтобы он отображался корректно на полкес учетом глубины
        draggableObject.SetSortingOrder(_shelfSortingOrder);
    }
}
