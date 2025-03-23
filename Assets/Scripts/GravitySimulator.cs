using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    // Сила гравитации, которая будет применяться к объектам
    [SerializeField] private float _gravity = 4f;
    // Y-координата, которая считается "землей" (уровнем, на котором объекты останавливаются)
    [SerializeField] private float _groundY;
    // Контейнер, который хранит все объекты, на которые будет действовать гравитация
    [SerializeField] private DraggableObjectContainer _objectStorage;

    private void Update()
    {
        // Применяем гравитацию к объектам каждый кадр
        ApplyGravity();
    }

    // Метод для применения гравитации к объектам
    private void ApplyGravity()
    {
        // Получаем список всех объектов, на которые может действовать гравитация
        List<DraggableObject> objects = _objectStorage.GetDraggableObjects();

        // Проходим по каждому объекту в списке
        foreach (DraggableObject obj in objects)
        {
            // Получаем текущую позицию объекта
            Vector3 position = obj.transform.position;

            // Если объект не в состоянии "Dropped" (не отпущен), пропускаем его
            if (obj.State != DraggableObjectState.Dropped)
            {
                continue;
            }

            // Если объект уже достиг уровня земли, устанавливаем его состояние "OnGround" и пропускаем
            if (position.y <= _groundY)
            {
                obj.SetState(DraggableObjectState.OnGround);
                continue;
            }

            // Применяем гравитацию: уменьшаем Y-координату объекта на величину, зависящую от силы гравитации и времени
            position.y -= _gravity * Time.deltaTime;

            // Устанавливаем новую позицию объекта, не позволяя ему опуститься ниже уровня земли
            obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, _groundY), position.z);
        }
    }
}
