using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{   public float baseSpeed = 3f; // �⺻ �̵� �ӵ�
    public float accelerationRate = 0.1f; // ���ӵ� ������ ���� ���
    private float timeElapsed = 0f;
    public Animator animator;
    public float jumpForce = 7f;  // ������ ���� ��
    public float jumpDuration = 0.5f; // ���� ���� �ð� (��)
    private bool isJumping = false;
    private float jumpStartTime;
    public bool isRight = true;//�����
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
                    //stack�� ���� �ӵ��� �ִ� ���� ���� ������ ����
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
            // ����Ű�� ���� ���ӵ� �ʱ�ȭ
            timeElapsed = 0f;
            TriggerSetReset( "stop","move");
            stack = 0;//���� ������ ���� �ʱ�ȭ
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpStartTime = Time.time;
        }
        // ���� ���� ��
        if (isJumping)
        {

            TriggerSetReset("jump", "notJump");
            // ���� ���� �ð� ���� �÷��̾ ���� ������
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