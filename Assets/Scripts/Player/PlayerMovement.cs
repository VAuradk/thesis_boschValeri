using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput inputPlayer = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    [SerializeField] private float moveSpeed = 10f;

    private void Awake()
    {
        inputPlayer = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputPlayer.Enable();
        inputPlayer.Player.Move.performed += OnMovementPerformed;
        inputPlayer.Player.Move.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        inputPlayer.Disable();
        inputPlayer.Player.Move.performed -= OnMovementPerformed;
        inputPlayer.Player.Move.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
