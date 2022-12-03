using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxDistance;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    private void SetTargetPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }

    public void TryMoveUp()
    {
        if (transform.position.y < _maxDistance)
        {
            SetTargetPosition(_stepSize);
        }
    }

    public void TryMoveDown()
    {
        if (transform.position.y > _maxDistance * -1)
        {
            SetTargetPosition(_stepSize * -1);
        }
    }
}