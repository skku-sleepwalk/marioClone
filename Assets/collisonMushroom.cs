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
        // ��ũ��Ʈ�� ����� ������Ʈ�� Collider2D ������Ʈ�� ������
        myCollider = GetComponent<BoxCollider2D>();
    }
    public bool eaten=false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
 
        // �ε��� ������Ʈ�� �±װ� "bush"���� Ȯ��
        if (collision.gameObject.tag == "Mushroom")
        {
            if (!eaten)
            {
            // �ִϸ��̼� Ʈ���� "TriggerName"�� ���� (���ϴ� Ʈ���� �̸����� �ٲټ���)
            animator.SetBool("bigger",true);
            animator.SetBool("smaller", false);
            myCollider.size= new Vector2(myCollider.size.x, myCollider.size.y*2f);
                eaten = true;
                StopWhileChanging.stop = true;
            }
            
        }
    }
}
