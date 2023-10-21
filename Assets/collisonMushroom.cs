using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonMushroom : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private BoxCollider2D myCollider;
    private void Start()
    {
        // 스크립트가 적용된 오브젝트의 Collider2D 컴포넌트를 가져옴
        myCollider = GetComponent<BoxCollider2D>();
    }
    public bool eaten=false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
 
        // 부딪힌 오브젝트의 태그가 "bush"인지 확인
        if (collision.gameObject.tag == "Mushroom")
        {
            if (!eaten)
            {
            // 애니메이션 트리거 "TriggerName"을 설정 (원하는 트리거 이름으로 바꾸세요)
            animator.SetBool("bigger",true);
            animator.SetBool("smaller", false);
            myCollider.size= new Vector2(myCollider.size.x, myCollider.size.y*2f);
                eaten = true;
                StopWhileChanging.stop = true;
            }
            
        }
    }
}
