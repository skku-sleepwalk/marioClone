using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBox : MonoBehaviour
{
    public float jumpForce; // 점프 힘
    public string targetTag = "MainMarioHead"; // 대상 오브젝트의 태그
    public float jumpCooldown = 2.0f; // 점프 후 대기 시간 (초)

    private bool canJump = false;
    private Rigidbody2D rb;
    private Vector3 originalPosition; // originalPosition 변수는 한 번만 정의
    private bool isJumping = false;
    private float jumpStartTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position; // originalPosition을 이곳에서 초기화
    }

    private void Update()
    {
        if (canJump && !isJumping )
        {
            Jump();
        }

        if (isJumping && Time.time - jumpStartTime >= jumpCooldown)
        {
            ReturnToOriginalPosition();
        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            canJump = false;
        }
    }

    public bool Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
        jumpStartTime = Time.time;
        Debug.Log("qqqq");
        Coin.flag2=true;
        return true;
    }

    private void ReturnToOriginalPosition()
    {
        isJumping = false;
        rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        transform.position = originalPosition;
    }

    // 갈색박스로 변함(코루틴?)
    // collision.gameObject.GetComponent<SpriteRenderer>().sprite = Box;
}
