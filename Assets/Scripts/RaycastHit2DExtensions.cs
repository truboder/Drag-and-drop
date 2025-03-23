using UnityEngine;

// Статический класс для расширения функциональности RaycastHit2D
public static class RaycastHit2DExtensions
{
    // Метод расширения для RaycastHit2D, который пытается получить компонент типа T
    public static bool TryGetComponent<T>(this RaycastHit2D hit, out T component) where T : Component
    {
        // Проверяем, есть ли коллайдер у объекта, с которым произошло столкновение
        if (hit.collider == null)
        {
            // Если коллайдера нет, возвращаем null и false
            component = null;
            return false;
        }

        // Пытаемся получить компонент типа T у коллайдера
        component = hit.collider.GetComponent<T>();

        // Возвращаем true, если компонент был найден, иначе false
        return component != null;
    }
}
