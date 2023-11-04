using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonMushroom : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private BoxCollider2D myCollider;
    public RuntimeAnimatorController controller;
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
            //animator.SetBool("bigger",true);
            //animator.SetBool("smaller", false);
                animator.runtimeAnimatorController = controller;
            myCollider.size= new Vector2(myCollider.size.x, myCollider.size.y*2f);
                eaten = true;
                Stop.stop = true;
                Stop.stopTime = 0.9f;
            }
            
        }
    }
}
