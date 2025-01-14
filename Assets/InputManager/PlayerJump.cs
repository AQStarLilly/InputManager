using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Actions.OnJump += HandleJump;
    }

    private void OnDisable()
    {
        Actions.OnJump -= HandleJump;
    }

    private void HandleJump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}