using UnityEngine;

// Атрибут, который позволяет создавать объекты этого класса через меню создания ассетов в Unity
[CreateAssetMenu(fileName = "WorldBounds", menuName = "ScriptableObjects/WorldBounds", order = 1)]
public class WorldBounds : ScriptableObject
{
    // Поле для хранения диапазона по оси X
    [SerializeField] private Range<float> _boundsX;
    // Поле для хранения диапазона по оси Y
    [SerializeField] private Range<float> _boundsY;

    // Свойство для получения диапазона по оси X
    public Range<float> BoundsX => _boundsX;
    // Свойство для получения диапазона по оси Y
    public Range<float> BoundsY => _boundsY;
}