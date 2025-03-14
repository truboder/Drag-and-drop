using UnityEngine;

public class ObjectFaller : MonoBehaviour
{
    [SerializeField] private float gravity = 4f;
    [SerializeField] private float groundY = 0f;

    void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        Collider2D[] objects = FindObjectsOfType<Collider2D>();

        foreach (var obj in objects)
        {
            DraggableObject draggableObject = obj.GetComponent<DraggableObject>();
            if (draggableObject == null) continue;

            Vector3 position = obj.transform.position;

            if (position.y > groundY)
            {
                position.y -= gravity * Time.deltaTime;
                obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, groundY), position.z);
            }
        }
    }
}
