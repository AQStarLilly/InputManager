using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameInput _inputActions;

    private void Awake()
    {
        _inputActions = new GameInput();
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _inputActions.Gameplay.Move.performed += ctx => Actions.OnMove?.Invoke(ctx.ReadValue<Vector2>());
        _inputActions.Gameplay.Move.canceled += ctx => Actions.OnMove?.Invoke(Vector2.zero);

        _inputActions.Gameplay.Jump.performed += _ => Actions.OnJump?.Invoke();
        _inputActions.Gameplay.Interact.performed += _ => Actions.OnInteract?.Invoke();
    }

    private void OnDisable()
    {
        _inputActions.Disable();

        // Unsubscribe input events
        _inputActions.Gameplay.Move.performed -= ctx => Actions.OnMove?.Invoke(ctx.ReadValue<Vector2>());
        _inputActions.Gameplay.Move.canceled -= ctx => Actions.OnMove?.Invoke(Vector2.zero);

        _inputActions.Gameplay.Jump.performed -= _ => Actions.OnJump?.Invoke();
        _inputActions.Gameplay.Interact.performed -= _ => Actions.OnInteract?.Invoke();
    }
}
