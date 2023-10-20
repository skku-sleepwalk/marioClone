using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravityPower;
    //float jumping = 0f;
    public float baseSpeed = 2f; // 기본 이동 속도
    public float accelerationRate = 0.1f; // 가속도 조절을 위한 상수
    private float timeElapsed = 0f;
    public Animator animator;
    //public float jumpForce = 10f;  // 점프에 사용될 힘
    //public float jumpDuration = 1f; // 점프 지속 시간 (초)

    //private bool isJumping = false;
    //private float jumpStartTime;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * gravityPower);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            timeElapsed += Time.deltaTime;
            float speed = baseSpeed + Mathf.Log(1 + accelerationRate * timeElapsed);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.right = Vector3.right;
            animator.ResetTrigger("stop");
            animator.SetTrigger("move");
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            timeElapsed += Time.deltaTime;
            float speed = baseSpeed + Mathf.Log(1 + accelerationRate * timeElapsed);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.right = Vector3.left;
            animator.ResetTrigger("stop");
            animator.SetTrigger("move");
        }
        else
        {
            // 방향키를 떼면 가속도 초기화
            timeElapsed = 0f;
            animator.ResetTrigger("move");
            animator.SetTrigger("stop");
        }
        //if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        //{
        //    isJumping = true;
        //    jumpStartTime = Time.time;
        //}

        //// 점프 중일 때
        //if (isJumping)
        //{
        //    // 점프 지속 시간 동안 플레이어를 위로 움직임
        //    float elapsedTime = Time.time - jumpStartTime;
        //    if (elapsedTime < jumpDuration)
        //    {
        //        float jumpProgress = elapsedTime / jumpDuration;
        //        float jumpHeight = Mathf.Lerp(0f, jumpForce, jumpProgress);
        //        transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
        //    }
        //    else
        //    {
        //        // 점프가 끝났을 때
        //        isJumping = false;
        //    }
        //}
    }
}
