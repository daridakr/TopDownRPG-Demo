using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;

    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int LastXDirection = Animator.StringToHash("LastXDirection");
    private static readonly int LastYDirection = Animator.StringToHash("LastYDirection");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool(IsMoving, _movement.IsMoving);
        _animator.SetFloat(Horizontal, _movement.NormalizedDirection.x);
        _animator.SetFloat(Vertical, _movement.NormalizedDirection.y);
        _animator.SetFloat(LastXDirection, _movement.LastDirection.x);
        _animator.SetFloat(LastYDirection, _movement.LastDirection.y);
    }
}
