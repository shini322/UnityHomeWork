using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider2D;
    private bool _isJumped = false;
    
    private Vector3 MovementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }
    
    private bool _isGrounded
    {
        get {
            Vector3 bottomCenterPoint = new Vector3(_collider2D.bounds.center.x, _collider2D.bounds.min.y, _collider2D.bounds.center.z);

            return Physics.CheckBox(bottomCenterPoint, bottomCenterPoint, _collider2D.bounds.size.x);
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        transform.Translate(MovementVector * _speed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}
