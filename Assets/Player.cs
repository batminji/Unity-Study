using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private float xInput;
    [SerializeField] private float moveSpeed = 3.5f;     // SerializeField : private 필드에 인스펙터에서 접근 가능하도록 허용
    [SerializeField] private float jumpForce = 8.0f;

    [SerializeField] private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();       // GetComponentInChildren : 자식 오브젝트에 있는 컴포넌트도 가져올 수 있음
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimations();
        HandleFlip();
    }

    private void HandleAnimations()
    {
        bool isMoving = rb.linearVelocityX != 0;        // linearVelocityX : Rigidbody2D의 수평 속도

        anim.SetBool("isMoving", isMoving);             // SetBool : Animator Controller의 파라미터를 설정
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");        // GetAxisRaw : 입력값을 -1, 0, 1로 반환 (왼쪽, 없음, 오른쪽)

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

    private void HandleFlip()
    {
        if(rb.linearVelocityX > 0 && facingRight == false)
        {
            Flip();
        }
        else if(rb.linearVelocityX < 0 && facingRight == true)
        {
            Flip();
        }
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
