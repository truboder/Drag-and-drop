using UnityEngine;

public static class RaycastHit2DExtensions
{
    public static bool TryGetComponent<T>(this RaycastHit2D hit, out T component) where T : Component
    {
        if (hit.collider == null)
        {
            component = null;
            return false;
        }

        component = hit.collider.GetComponent<T>();
        return component != null;
    }
}
