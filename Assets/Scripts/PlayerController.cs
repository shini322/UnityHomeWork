using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Animator _animator;

    private const string HorizontalAxisRawKey = "Horizontal";
    private const string IsMovingAnimationKey = "isMoving";
    private const string IsJumpingAnimationKey = "isJumping";
    private const float LineCastOffSet = 0.01f;

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider2D;
    private bool _isFacingRight = true;

    private bool _isGrounded
    {
        get
        {
            Vector3 start = new Vector3(_collider2D.bounds.min.x, _collider2D.bounds.min.y - LineCastOffSet);
            Vector3 end = new Vector3(_collider2D.bounds.max.x, _collider2D.bounds.min.y - LineCastOffSet);
            RaycastHit2D hit = Physics2D.Linecast(start, end, _groundLayerMask);
            return hit.collider != null;
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
        float horizontal = Input.GetAxisRaw(HorizontalAxisRawKey);
        _rigidbody2D.velocity = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);
        _animator.SetBool(IsMovingAnimationKey, horizontal != 0);
            
        if (_isFacingRight && horizontal < 0 || !_isFacingRight && horizontal > 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && _isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _animator.SetBool(IsJumpingAnimationKey, true);
        }

        _animator.SetBool(IsJumpingAnimationKey, !_isGrounded);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}