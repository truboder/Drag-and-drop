using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] private float maxAllowedY = 4f;

    public void Move(Vector2 newPosition)
    {
        transform.position = new Vector2(newPosition.x, newPosition.y);
    }

    public void Release()
    {
        Vector3 position = transform.position;

        if (position.y > maxAllowedY)
        {
            position.y = maxAllowedY;
        }

        transform.position = position;
    }
}
