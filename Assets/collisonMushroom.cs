using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonMushroom : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 부딪힌 오브젝트의 태그가 "bush"인지 확인
        if (collision.gameObject.tag == "Mushroom")
        {
            // 애니메이션 트리거 "TriggerName"을 설정 (원하는 트리거 이름으로 바꾸세요)
            animator.SetBool("bigger",true);
            animator.SetBool("smaller", false);
        }
    }
}
