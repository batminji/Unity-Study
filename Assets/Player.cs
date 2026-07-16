using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private float xInput;
    [SerializeField] private float moveSpeed = 3.5f;     // SerializeField : private 필드에 인스펙터에서 접근 가능하도록 허용
    [SerializeField] private float jumpForce = 8.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }
}
