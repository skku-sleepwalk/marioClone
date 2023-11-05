using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public static bool stop=false;
    public static float stopTime;
    public Animator animator;
    private Rigidbody2D rb;
    void Update()
    {
        if (stop)
        {
            move.canMove = false;
            rb = GetComponent<Rigidbody2D>();
            float gravityScaletmp = rb.gravityScale;
            rb.gravityScale = 0;
            stop = false;
            StartCoroutine(EnableMovementAfterDelay(stopTime, gravityScaletmp));
        }
    }
    IEnumerator EnableMovementAfterDelay(float delay,float gravityScaletmp)
    {
        // delay �ð���ŭ ����մϴ�.
        yield return new WaitForSeconds(delay);

        // ���� �ð��� ���� �Ŀ� �� �κ��� �ڵ尡 ����˴ϴ�.
        move.canMove = true;
        rb.gravityScale = gravityScaletmp;
        // �߰����� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
        animator.SetTrigger("noDrift");

    }
}
