using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    [SerializeField] private float _gravity = 4f;
    [SerializeField] private float _groundY = 0f;
    [SerializeField] private InteractiveObjectStorage _objectStorage;
    //[SerializeField] private LayerMask _shelfLayer;

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

            if (position.y <= _groundY || obj.State == DraggableObjectState.Captured || obj.State == DraggableObjectState.OnShelf)
            {
                continue;
            }

            obj.SetState(DraggableObjectState.Falling);

            //if (IsAboveShelf(obj, out Shelf shelf))
            //{
            //    shelf.PlaceObjectOnShelf(obj);
            //    continue;
            //}

            position.y -= _gravity * Time.deltaTime;

           
            obj.transform.position = new Vector3(position.x, Mathf.Max(position.y, _groundY), position.z);
        }
    }

    //private bool IsAboveShelf(DraggableObject obj, out Shelf shelf)
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(obj.transform.position, Vector2.down, Mathf.Infinity, _shelfLayer);

    //    if (hit.collider != null)
    //    {
    //        shelf = hit.collider.GetComponent<Shelf>();
    //        return shelf != null;
    //    }

    //    shelf = null;
    //    return false;
    //}
}
