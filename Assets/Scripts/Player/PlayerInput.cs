using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void OnMove(InputValue input)
    {
        var direction = input.Get<Vector2>();
        _movement.SetDirection(direction);
    }
}
