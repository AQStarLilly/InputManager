using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 _moveInput;

    private void OnEnable()
    {
        Actions.OnMove += HandleMove;
    }

    private void OnDisable()
    {
        Actions.OnMove -= HandleMove;
    }

    private void HandleMove(Vector2 input)
    {
        _moveInput = input;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}