using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopWhileChanging : MonoBehaviour
{
    public static bool stop=false;
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
            StartCoroutine(EnableMovementAfterDelay(0.9f, gravityScaletmp));
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
    }
}
