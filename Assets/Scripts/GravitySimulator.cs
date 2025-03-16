using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    [SerializeField] private float _gravity = 4f;
    [SerializeField] private float _groundY = 0f;
    [SerializeField] private InteractiveObjectStorage _objectStorage;

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        List<DraggableObject> objects = _objectStorage.GetFallers();

        foreach (DraggableObject obj in objects)
        {
            Vector3 position = obj.transform.position;

            if (position.y <= _groundY || obj.IsCaptured)
            {
                continue;
            }          
            
            position.y -= _gravity * Time.deltaTime;
            obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, _groundY), position.z);
        }
    }
}
