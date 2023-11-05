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
        // delay 시간만큼 대기합니다.
        yield return new WaitForSeconds(delay);

        // 일정 시간이 지난 후에 이 부분의 코드가 실행됩니다.
        move.canMove = true;
        rb.gravityScale = gravityScaletmp;
        // 추가적인 로직을 여기에 추가할 수 있습니다.
        animator.SetTrigger("noDrift");

    }
}
