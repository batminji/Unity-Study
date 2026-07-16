using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private float xInput;
    [SerializeField] private float moveSpeed = 3.5f;     // SerializeField : private 필드에 인스펙터에서 접근 가능하도록 허용

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // xInput = Input.GetAxis("Horizontal");        // -1 ~ 1 사이의 값 반환
        xInput = Input.GetAxisRaw("Horizontal");        // -1 또는 1로만 반환

        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }
}
