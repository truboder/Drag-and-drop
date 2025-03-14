using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    [SerializeField] private float _gravity = 4f;
    [SerializeField] private float _groundY = 0f;

    void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        DraggableObject[] objects = FindObjectsOfType<DraggableObject>();

        foreach (DraggableObject obj in objects)
        {
            DraggableObject draggableObject = obj.GetComponent<DraggableObject>();

            if (draggableObject == null) 
            {
                continue;
            }

            Vector3 position = obj.transform.position;

            if (obj.IsCaptured == false)
            {
                if (position.y > _groundY)
                {
                    position.y -= _gravity * Time.deltaTime;
                    obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, _groundY), position.z);
                }
            }
        }
    }
}
