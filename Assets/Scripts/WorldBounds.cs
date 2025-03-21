using UnityEngine;

[CreateAssetMenu(fileName = "WorldBounds", menuName = "ScriptableObjects/WorldBounds", order = 1)]
public class WorldBounds : ScriptableObject
{
    [SerializeField] private Range<float> _boundsX;
    [SerializeField] private Range<float> _boundsY;

    public Range<float> BoundsX => _boundsX;
    public Range<float> BoundsY => _boundsY;
}