using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [Header("Player Movement Settings")]
    private float xInput;
    [SerializeField] private float moveSpeed = 3.5f;     // SerializeField : private 필드에 인스펙터에서 접근 가능하도록 허용
    [SerializeField] private float jumpForce = 8.0f;
    private bool facingRight = true;

    [Header("Collision Settings")]
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();       // GetComponentInChildren : 자식 오브젝트에 있는 컴포넌트도 가져올 수 있음
    }

    private void Update()
    {
        HandleCollision();
        HandleInput();
        HandleMovement();
        HandleAnimations();
        HandleFlip();
    }

    private void HandleAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);                     // SetBool : Animator Controller의 파라미터를 설정
        anim.SetFloat("yVelocity", rb.linearVelocityY);             // SetFloat : Animator Controller의 파라미터를 설정
        anim.SetFloat("xVelocity", rb.linearVelocityX);
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
        if(isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        // Raycast : 레이저를 쏘아서 충돌 여부를 확인하는 함수
        // true : 충돌, false : 충돌하지 않음
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance, 0));    
    }
}
