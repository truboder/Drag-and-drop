using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    [SerializeField] private float _gravity = 4f;
    [SerializeField] private float _groundY;
    [SerializeField] private DraggableObjectContainer _objectStorage;

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        List<DraggableObject> objects = _objectStorage.GetDraggableObjects();

        foreach (DraggableObject obj in objects)
        {
            Vector3 position = obj.transform.position;

            if (obj.State != DraggableObjectState.Dropped)
            {
                continue;
            }

            if (position.y <= _groundY)
            {
                obj.SetState(DraggableObjectState.OnGround);
                continue;
            }

            position.y -= _gravity * Time.deltaTime;
            obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, _groundY), position.z);
        }
    }
}
