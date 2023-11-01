using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{   public float baseSpeed = 3f; // 기본 이동 속도
    public float accelerationRate = 0.1f; // 가속도 조절을 위한 상수
    private float timeElapsed = 0f;
    public Animator animator;
    public float jumpForce = 7f;  // 점프에 사용될 힘
    public float jumpDuration = 0.5f; // 점프 지속 시간 (초)
    private bool isJumping = false;
    private float jumpStartTime;
    public bool isRight = true;//꺾기용
    public static bool canMove = true;
    private int stack = 0;
    private void TriggerSetReset(string set,string reset)
    {
            animator.ResetTrigger(reset);
            animator.SetTrigger(set);
    }
    private void MoveHorizontal()
{
 if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isRight)
            {
                if (stack > 50)
                {
                    //stack이 차면 속도가 있는 것을 간주 멈춤을 적용
                    Stop.stop = true;
                    Stop.stopTime = 0.3f;
                    Debug.Log("drift!!!!");
                    animator.ResetTrigger("noDrift");
                    animator.SetTrigger("drift");
                }
                isRight= true;
                stack = 0;

            }
            timeElapsed += Time.deltaTime;
            float speed = baseSpeed + Mathf.Log(1 + accelerationRate * timeElapsed);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.right = Vector3.right;
            TriggerSetReset("move", "stop");
            stack++;
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isRight)
            {
                if (stack > 50)
                {
                    Stop.stop = true;
                    Stop.stopTime = 0.3f;

                    Debug.Log("drift!!!!");
                    animator.ResetTrigger("noDrift");
                    animator.SetTrigger("drift");
               
                }
                isRight = false;
                stack = 0;

            }
            timeElapsed += Time.deltaTime;
            float speed = baseSpeed + Mathf.Log(1 + accelerationRate * timeElapsed);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.right = Vector3.left;
            TriggerSetReset("move", "stop");
            stack++;

        }
        else
        {
            // 방향키를 떼면 가속도 초기화
            timeElapsed = 0f;
            TriggerSetReset( "stop","move");
            stack = 0;//멈춰 있으면 스택 초기화
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpStartTime = Time.time;
        }
        // 점프 중일 때
        if (isJumping)
        {

            TriggerSetReset("jump", "notJump");
            // 점프 지속 시간 동안 플레이어를 위로 움직임
            float elapsedTime = Time.time - jumpStartTime;
            if (elapsedTime < jumpDuration)
            {
                transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            }
        }
        else
        {
            TriggerSetReset("notJump", "jump");
        }
    }
    void Update()
    {
        if (canMove)
        {
 MoveHorizontal();
        Jump();
        }
       
    }
       public void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "QBoxTop"|| collision.gameObject.tag == "BoxTop"|| collision.gameObject.tag == "Ground")
            {
                 isJumping = false;
            }

    }
}   