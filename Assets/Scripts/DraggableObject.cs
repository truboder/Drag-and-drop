using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    // Ссылка на компонент SpriteRenderer для управления порядком отрисовки
    [SerializeField] SpriteRenderer _spriteRenderer;

    // Текущее состояние объекта (публичное свойство с приватным сеттером)
    public DraggableObjectState State {  get; private set; }

    // Метод для изменения состояния объекта
    public void SetState(DraggableObjectState newState)
    {
        // Проверяем, разрешен ли переход из текущего состояния в новое
        if (IsTransitionAllowed(State, newState))
        {
            // Если переход разрешен, обновляем состояние
            State = newState;
        }
        else
        {
            // Если переход не разрешен, выводим предупреждение в консоль
            Debug.Log("Transsion is not allowed");
        }
    }

    // Метод для установки порядка отрисовки спрайта
    public void SetSortingOrder(int order)
    {
        // Если SpriteRenderer существует, устанавливаем порядок отрисовки
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sortingOrder = order;
        }
    }

    // Метод для проверки, разрешен ли переход между состояниями
    private bool IsTransitionAllowed(DraggableObjectState currentState, DraggableObjectState newState)
    {
        // В зависимости от текущего состояния проверяем, разрешен ли переход в новое состояние
        switch (currentState)
        {
            // Из состояния "Captured" можно перейти в "Dropped", "OnShelf" или "OnGround"
            case DraggableObjectState.Captured:
                return newState == DraggableObjectState.Dropped || newState == DraggableObjectState.OnShelf || newState == DraggableObjectState.OnGround;
            
            // Из состояния "Dropped" можно перейти в "Captured", "OnShelf" или "OnGround"
            case DraggableObjectState.Dropped:
                return newState == DraggableObjectState.Captured || newState == DraggableObjectState.OnShelf || newState == DraggableObjectState.OnGround;
            
            // Из состояния "OnShelf" можно перейти только в "Captured"
            case DraggableObjectState.OnShelf:
                return newState == DraggableObjectState.Captured;
            
            // Из состояния "OnGround" можно перейти только в "Captured"
            case DraggableObjectState.OnGround:
                return newState == DraggableObjectState.Captured;
            
            // Для всех остальных случаев переход запрещен
            default:
                return false;
        }
    }
}

// Перечисление, определяющее возможные состояния объекта
public enum DraggableObjectState
{
    Captured, // Объект захвачен (например, игрок его перетаскивает)
    Dropped, // Объект отпущен (например, игрок перестал его перетаскивать)
    OnGround, // Объект находится на земле
    OnShelf // Объект находится на полке
}
