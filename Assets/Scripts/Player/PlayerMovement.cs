using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _collisionOffset = 0.05f;
    [SerializeField] private ContactFilter2D _filter;

    private Vector2 _direction;
    private bool _isMoving;
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();

    private Vector2 _horizontalDirection;
    private Vector2 _verticalDirection;
    private Vector2 _lastDirection;

    public Vector2 Direction => _direction;
    public Vector2 NormalizedDirection => _direction.normalized;
    public Vector2 LastDirection => _lastDirection;
    public bool IsMoving => _isMoving;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        _horizontalDirection = new Vector2(_direction.x, 0);
        _verticalDirection = new Vector2(0, _direction.y);
    }

    private void Update()
    {
        KeepLastDirection();
        UpdateSpriteDirection(_direction.x);
    }

    private void KeepLastDirection()
    {
        if (_direction.x != 0 || _direction.y != 0)
        {
            _lastDirection = _direction.normalized;
        }
    }

    private void UpdateSpriteDirection(float horizontalDirection)
    {
        if (horizontalDirection > 0)
        {
            _renderer.flipX = false;
        }
        else if (horizontalDirection < 0)
        {
            _renderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        _isMoving = false;

        if (_direction != Vector2.zero)
        {
            Vector2[] possibleDirections = { _direction, _horizontalDirection, _verticalDirection };

            foreach (Vector2 direction in possibleDirections)
            {
                if (TryMove(direction))
                {
                    _isMoving = true;
                    break;
                }
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = _body.Cast(direction, _filter, _castCollisions, _speed * Time.fixedDeltaTime + _collisionOffset);

            if (count == 0)
            {
                Move(direction);
                return true;
            }
        }

        return false;
    }

    private void Move(Vector2 direction)
    {
        _body.MovePosition(_body.position + direction * _speed * Time.fixedDeltaTime);
    }
}
