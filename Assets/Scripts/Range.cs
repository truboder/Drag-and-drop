using System;
using UnityEngine;

[Serializable]
// ќбобщенна€ структура Range, где T должен реализовывать интерфейс IComparable<T>
public struct Range<T> where T : IComparable<T>
{
    // ѕоле дл€ минимального значени€ диапазона
    [SerializeField] private T _min;
    // ѕоле дл€ максимального значени€ диапазона
    [SerializeField] private T _max;

    //  онструктор дл€ инициализации диапазона с минимальным и максимальным значени€ми
    public Range(T min, T max)
    {
        _min = min;
        _max = max;
    }

    // —войство дл€ получени€ минимального значени€ диапазона
    public T Min => _min;
    // —войство дл€ получени€ максимального значени€ диапазона
    public T Max => _max;

    // ћетод дл€ проверки, содержитс€ ли значение в диапазоне
    public bool Contains(T value)
    {
        // —равниваем значение с минимальным и максимальным значени€ми диапазона
        return value.CompareTo(_min) >= 0 && value.CompareTo(_max) <= 0;
    }
}
