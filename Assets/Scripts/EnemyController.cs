using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;
    
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    // private IEnumerator PatrolMovement(float target)
    // {
    //      _rigidbody2D.velocity = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);
    // }
}
