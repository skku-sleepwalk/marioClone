using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonMushroom : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // �ε��� ������Ʈ�� �±װ� "bush"���� Ȯ��
        if (collision.gameObject.tag == "Mushroom")
        {
            // �ִϸ��̼� Ʈ���� "TriggerName"�� ���� (���ϴ� Ʈ���� �̸����� �ٲټ���)
            animator.SetBool("bigger",true);
            animator.SetBool("smaller", false);
        }
    }
}
