using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Installer : MonoBehaviour
{
    [SerializeField] private WorldBounds _worldBounds;
    [SerializeField] private DraggableObjectContainer _draggableObjectContainer;
    [SerializeField] private ObjectMoveProcessor _objectMoveProcessor;

    private void Awake()
    {
        Container.Instance.Register<WorldBounds>(_worldBounds);
        Container.Instance.Register<DraggableObjectContainer>(_draggableObjectContainer);
        Container.Instance.Register<ObjectMoveProcessor>(_objectMoveProcessor);
    }
}
