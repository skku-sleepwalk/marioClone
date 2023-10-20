using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravityPower;
    //float jumping = 0f;
    public float baseSpeed = 2f; // �⺻ �̵� �ӵ�
    public float accelerationRate = 0.1f; // ���ӵ� ������ ���� ���
    private float timeElapsed = 0f;
    public Animator animator;
    //public float jumpForce = 10f;  // ������ ���� ��
    //public float jumpDuration = 1f; // ���� ���� �ð� (��)

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
            // ����Ű�� ���� ���ӵ� �ʱ�ȭ
            timeElapsed = 0f;
            animator.ResetTrigger("move");
            animator.SetTrigger("stop");
        }
        //if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        //{
        //    isJumping = true;
        //    jumpStartTime = Time.time;
        //}

        //// ���� ���� ��
        //if (isJumping)
        //{
        //    // ���� ���� �ð� ���� �÷��̾ ���� ������
        //    float elapsedTime = Time.time - jumpStartTime;
        //    if (elapsedTime < jumpDuration)
        //    {
        //        float jumpProgress = elapsedTime / jumpDuration;
        //        float jumpHeight = Mathf.Lerp(0f, jumpForce, jumpProgress);
        //        transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
        //    }
        //    else
        //    {
        //        // ������ ������ ��
        //        isJumping = false;
        //    }
        //}
    }
}
